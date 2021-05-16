using Microsoft.EntityFrameworkCore;
using System;

namespace CoffeeMachine.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable 
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int Save();
    }
}
