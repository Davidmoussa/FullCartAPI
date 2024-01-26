using FullCartApp.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly dbContext _dbContext;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(dbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (!_repositories.ContainsKey(typeof(TEntity)))
            {
                _repositories[typeof(TEntity)] = new Repository<TEntity>(_dbContext);
            }

            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
