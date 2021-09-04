using SecretProject.BusinessProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SecretProject.BusinessProject.DataAccess
{

    public interface IRepository : IAsyncDisposable
    {
        Task<TEntity> GetByIdAsync<TEntity>(int id, CancellationToken cancellationToken) where TEntity : class,IDomainObject;

        Task<TEntity> GetByIdAsync<TEntity>(Guid id, CancellationToken cancellationToken) where TEntity : class, IDomainObject;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, int count = 1,
            int skip = 0) where TEntity : class, IDomainObject;

        Task<bool> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class,IDomainObject;

        Task<bool> RemoveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class,IDomainObject;

        Task<bool> SaveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class,IDomainObject;
    }
}
