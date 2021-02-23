using RentoLibData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentoLibData.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> UserLogin(string username, string password);
        Task<User> GetById(int id);
    }
}
