using RentoLibData.Interfaces.Repositories;
using System;

namespace RentoLibData.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }


    }
}
