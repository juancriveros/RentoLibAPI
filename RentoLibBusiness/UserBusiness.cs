using RentoLibData;
using RentoLibData.Interfaces;
using RentoLibData.Interfaces.Services;
using RentoLibData.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RentoLibBusiness
{
    public class UserBusiness : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<User> UserLogin(string username, string password)
        {
            password = HashPassword(password);
            return await _unitOfWork.Users.UserLogin(username, password);
        }

        public async Task<User> GetById(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        private string HashPassword(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
