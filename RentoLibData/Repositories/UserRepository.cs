using Microsoft.EntityFrameworkCore;
using RentoLibData.Context;
using RentoLibData.Interfaces.Repositories;
using RentoLibData.Models;
using RentoLibData.Repositories;
using System;
using System.Threading.Tasks;

namespace RentoLibData
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RentoLibContext context)
           : base(context)
        { }

        public async Task<User> UserLogin(string username, string password)
        {
            var user = await RentoLibContext.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);

            return user;
        }

        private RentoLibContext RentoLibContext
        {
            get { return Context as RentoLibContext; }
        }
    }
}
