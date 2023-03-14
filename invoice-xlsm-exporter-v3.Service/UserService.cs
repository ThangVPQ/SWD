using Firebase.Database;
using invoice_xlsm_exporter_v3.Data.Abstract;
using invoice_xlsm_exporter_v3.Domain.Entities;
using invoice_xlsm_exporter_v3.Dto;
using invoice_xlsm_exporter_v3.Service.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace invoice_xlsm_exporter_v3.Service
{
    public class UserService : IUserService
    {
        IRepository<User> _userRepository;
        IDapperHelper _dapperHelper;
        private string HashData(string data)
        {
            string output = "SWD";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(data);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            mang = md5.ComputeHash(mang);
            foreach (byte b in mang)
            {
                output += b.ToString();
            }
            if (output.Length > 50)
            {
                output = output.Substring(0, 49);
            }
            return output;
        }
        public UserService(IRepository<User> userRepository, IDapperHelper dapperHelper)
        {
            _userRepository = userRepository;
            _dapperHelper = dapperHelper;
        }
        public async Task<ResponseEntity> GetUsers()
        {
            try
            {
                return new ResponseEntity(await _userRepository.GetData(), true);

            }
            catch (Exception e)
            {
                return new ResponseEntity(null, false);
            }
        }

        public async Task<ResponseEntity> GetUserById(int userId)
        {
            return new ResponseEntity(await _userRepository.GetById(userId), true);
        }
        public async Task<ResponseEntity> GetUserByName(String userName)
        {
            try
            {
                var data = await _userRepository.GetData();
                foreach (var user in data)
                {
                    if (user.UserName.Equals(userName)) return new ResponseEntity(user, true);
                }
                return new ResponseEntity(null, false);
            }
            catch (Exception e)
            {
                return new ResponseEntity(null, false);
            }

        }
        public async Task<ResponseEntity> CheckLogin(String userName, String password)
        {
            var data = await _userRepository.GetData();
            foreach (var user in data)
            {
                if (user.UserName.Equals(userName) && user.Password.Equals(HashData(password))) return new ResponseEntity(user, true);
            }
            return new ResponseEntity(null, false);
        }
        private async Task<int> CheckNewId()
        {
            int id = 0;
            var data = await _userRepository.GetData();
            foreach (var user in data)
            {
                if (user.Id > id)
                {
                    id = user.Id;
                }
            }
            return id++;
        }
        public async Task<ResponseEntity> InsertUser(User user)
        {
            int id = 0;
            user.Role = "USER";
            user.CreatedDay = DateTime.Now;
            user.Status = "active";
            var data = await _userRepository.GetData();
            foreach (var u in data)
            {
                id = u.Id;
            }
            if (!GetUserByName(user.UserName).Result.Status)
            {
                user.Password = HashData(user.Password);
                _userRepository.Insert(user);
                _userRepository.Commit();
                user.Id = id + 1;
                return new ResponseEntity(user, true);
            }
            return new ResponseEntity(user, false);
        }

        public async Task InsertUsers(IEnumerable<User> users)
        {
            await _userRepository.Insert(users);
            await _userRepository.Commit();

        }

        public async Task<ResponseEntity> UpdateUser(User user)
        {
            if (GetUserByName(user.UserName).Result.Status)
            {
                User userUpdate = (User)GetUserByName(user.UserName).Result.Data;
                if (user.Email != null) userUpdate.Email = user.Email;
                if (user.Status.Equals("active") || user.Status.Equals("disable")) userUpdate.Status = user.Status;
                if (user.Password != null) userUpdate.Password = HashData(user.Password);
                _userRepository.Update(userUpdate);
                _userRepository.Commit();
                return new ResponseEntity(user, true);
            }
            return new ResponseEntity(user, false);

        }

        public void DeleteUser(User user)
        {
            _userRepository.Delete(user);
            _userRepository.Commit();
        }

        public void DeleteUser(Expression<Func<User, bool>> expression)
        {
            _userRepository.Delete(expression);
            _userRepository.Commit();

        }
        public async Task<ResponseEntity> UpLoadFeedBackAsync(string username, string comment)
        {
            try {
                FirebaseClient firebaseClient = new FirebaseClient("https://swdinvoice-45100-default-rtdb.firebaseio.com/");
                FeedBack feedBack = new FeedBack();
                feedBack.Username = username;
                feedBack.Commnent = comment;
                feedBack.DateCommnet = DateTime.Now;
                firebaseClient.Child("comment").PostAsync(feedBack);
                return new ResponseEntity(feedBack, true);
            }
            catch (Exception)
            {
                return new ResponseEntity(null, false);
            }
            
        }
        public async Task<ResponseEntity> GetAllFeedBack()
        {
            try
            {
                FirebaseClient firebaseClient = new FirebaseClient("https://swdinvoice-45100-default-rtdb.firebaseio.com/");
                var firebaseObject = await firebaseClient.Child("comment").OnceAsync<Object>();
                var listFeedBack = new List<FeedBack>();
                foreach (var u in firebaseObject)
                {
                    FeedBack fb = JsonConvert.DeserializeObject<FeedBack>(u.Object.ToString());
                    listFeedBack.Add(fb);
                }
                return new ResponseEntity(listFeedBack, true);
            }
            catch (Exception)
            {
                return new ResponseEntity(null, false);
            }
        }
    }
}
