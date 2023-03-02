using invoice_xlsm_exporter_v3.Domain.Entities;
using invoice_xlsm_exporter_v3.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Service
{
    public interface IUserService
    {
        void DeleteUser(User user);
        void DeleteUser(Expression<Func<User, bool>> expression);
        Task<ResponseEntity> GetUserById(int userId);
        Task<ResponseEntity> GetUsers();
        Task<ResponseEntity> InsertUser(User user);
        Task InsertUsers(IEnumerable<User> users);
        Task<ResponseEntity> UpdateUser(User user);
        Task<ResponseEntity> CheckLogin(String userName, String password);
    }
}