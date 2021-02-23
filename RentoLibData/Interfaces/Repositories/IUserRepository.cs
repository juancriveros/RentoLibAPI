using RentoLibData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentoLibData.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> UserLogin(string username, string password);
    }
}
