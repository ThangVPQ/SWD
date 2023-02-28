using invoice_xlsm_exporter_v3.Data.Abstract;
using invoice_xlsm_exporter_v3.Domain.Entities;
using invoice_xlsm_exporter_v3.Dto;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
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
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetData();
            //use dapper (sql string to query)
            //string sql = $"SELECT * FROM Users";
            //return await _dapperHelper.ExcuteSqlReturnList<User>(sql);
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _userRepository.GetById(userId);
        }
        public async Task<ResponseEntity> GetUserByName(String userName)
        {
            //return await _userRepository.GetData();
            //use dapper (sql string to query)
            var data = await GetUsers();
            foreach (var user in data)
            {
                if (user.UserName.Equals(userName)) return new ResponseEntity(user, true);
            }
            return new ResponseEntity(null, false);
        }
        public async Task<ResponseEntity> CheckLogin(String userName, String password)
        {

            var data = await GetUsers();
            foreach (var user in data)
            {
                if (user.UserName.Equals(userName) && user.Password.Equals(HashData(password))) return new ResponseEntity(user, true);
            }
            return new ResponseEntity(null, false);
        }

        //public async Task<User> CheckUser(string userName, string password)
        //{
        //    var user = await _userRepository.GetData<User>(u => u.Username == username && u.Password == password);
        //    return user.Any();
        //}

        public ResponseEntity InsertUser(User user)
        {
            user.Role = "USER";
            user.CreatedDay = DateTime.Now;
            user.Status = "active";
            if (!GetUserByName(user.UserName).Result.Status){
                user.Password = HashData(user.Password);
                _userRepository.Insert(user);
                _userRepository.Commit();
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
                userUpdate.Email = user.Email;
                userUpdate.Password = HashData(user.Password);
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




    }
}
