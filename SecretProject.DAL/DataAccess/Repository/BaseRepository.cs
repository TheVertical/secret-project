using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models;
using SecretProject.BusinessProject.Models.Common;

namespace SecretProject.DAL.DataAccess.Repository
{
    public class BaseRepository : IRepository, IAsyncDisposable
    {
        protected readonly ILogger Logger;
        protected readonly DbContext Context;
        
        public BaseRepository(ILogger logger, DbContext context)
        {
            this.Logger = logger;
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public async Task<bool> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
            where TEntity : class, IDomainObject

        {
            await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
            int state = await SaveAsync();

            return Enum.IsDefined(typeof(EntityState), state) && (EntityState) state == EntityState.Added;
        }

        public async Task<bool> AddAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
            where TEntity : class, IDomainObject
        {
            await Context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            int state = await SaveAsync();

            return Enum.IsDefined(typeof(EntityState), state) && (EntityState)state == EntityState.Added;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id, CancellationToken cancellationToken)
            where TEntity : class, IDomainObject
        {
            return await Context.Set<TEntity>().FindAsync(id, cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(Guid id, CancellationToken cancellationToken)
            where TEntity : class, IDomainObject
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, int count = 1,
            int skip = 0)
            where TEntity : class, IDomainObject
        {
            var result = await Context.Set<TEntity>().AsNoTracking().Where(predicate).Skip(skip).Take(count).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<bool> RemoveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
            where TEntity : class, IDomainObject
        {
            Context.Entry(entity).State = EntityState.Deleted;

            int state = await SaveAsync();
            return Enum.IsDefined(typeof(EntityState), state) && (EntityState)state == EntityState.Deleted;
        }

        private async Task<int> SaveAsync()
        {
            int state = 0;

            try
            {
                state = await Context.SaveChangesAsync();
            }
            catch (SqlException exception)
            {
                Logger.LogError(exception, "");
            }

            return state;
        }
        public async Task<bool> SaveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
            where TEntity : class, IDomainObject
        {
            Context.Entry(entity).State = EntityState.Modified;
            int state = await SaveAsync();
            if (Enum.IsDefined(typeof(EntityState), state) && (EntityState)state == EntityState.Modified)
                return false;
            return true;
        }

        public async ValueTask DisposeAsync()
        {
            await Context.DisposeAsync();
        }
    }
}
