using RentoLibData.Context;
using RentoLibData.Interfaces;
using RentoLibData.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentoLibData
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentoLibContext _context;
        private UserRepository _userRepository;

        public UnitOfWork(RentoLibContext context)
        {
            this._context = context;
        }

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
