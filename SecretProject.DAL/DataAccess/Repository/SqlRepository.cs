using Microsoft.EntityFrameworkCore;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models;
using SecretProject.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SecretProject.DAL.DataAccess
{
    public class SqlRepository<Entity> : IRepository<Entity>
        where Entity : class, IDomainObject
    {

        #region Model
        private readonly DbSet<Entity> table;
        private readonly DbContext context;
        #endregion

        #region Realization
        public SqlRepository() : this((new sBaseContextFactory()).CreateDbContext(null)) { }
        public SqlRepository(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            table = context.Set<Entity>();
        }
        #endregion

        #region Interface's Methods
        public void Add(Entity entity)
        {
            table.Add(entity);
            Save();
        }
        public void Add(IList<Entity> entities)
        {
            table.AddRange(entities);
            Save();
        }
        public Entity GetById(int id)
        {
            return table.Find(id);
        }
        public IEnumerable<Entity> Get(int count,Expression<Func<Entity,bool>> predicate)
        {
            return table.Where(predicate).Take(count).ToList();
        }
        public IEnumerable<Entity> GetAll<TSortField>(Expression<Func<Entity,TSortField>> orderBy,bool ascending)
        {
            return ascending ? table.OrderBy(orderBy) : table.OrderByDescending(orderBy);
        }
        public void Remove(Entity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            Save();
        }
        public void Update(Entity entity)
        {
            throw new NotImplementedException();
        }
        private void Save()
        {
            context.SaveChanges();
        }
        public void Save(Entity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        #region async
        public async Task<bool> AddAsync(Entity entity)
        {
            table.Add(entity);
            int state = await SaveAsync();
            if (Enum.IsDefined(typeof(EntityState),state) && (EntityState)state == EntityState.Added)
                return false;
            return true;
        }
        public async Task<bool> AddAsync(IList<Entity> entities)
        {
            table.AddRange(entities);
            int state = await SaveAsync();
            if (Enum.IsDefined(typeof(EntityState), state) && (EntityState)state == EntityState.Added)
                return true;
            else
                return false;
        }
        public async Task<Entity> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }
        public async Task<IEnumerable<Entity>> GetAsync(int count, Expression<Func<Entity, bool>> predicate)
        {
            return await table.Where(predicate).Take(count).ToListAsync();
        }
        public async Task<IEnumerable<Entity>> GetAllAsync<TSortField>(Expression<Func<Entity, TSortField>> orderBy, bool ascending)
        {
            return ascending ? await table.OrderBy(orderBy).ToListAsync() : await table.OrderByDescending(orderBy).ToListAsync();
        }
        public async Task<bool> RemoveAsync(Entity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            int state = await SaveAsync();
            if (Enum.IsDefined(typeof(EntityState),state) && (EntityState)state == EntityState.Deleted)
                return false;
            return true;
        }
        private async Task<int> SaveAsync()
        {
            int state = 0;
            try
            {
                state = await context.SaveChangesAsync();
            }
            //TODO Сделать нормальную обработку исключений в SaveChange и SaveChangeAsync
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return state;
        }
        public async Task<bool> SaveAsync(Entity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            int state = await SaveAsync();
            if (Enum.IsDefined(typeof(EntityState),state) && (EntityState)state == EntityState.Modified)
                return false;
            return true;
        }
        #endregion


        #endregion
    }

    public class SqlRepository : IRepository,IDisposable
    {
        #region Model
        private DbContext context;
        #endregion

        #region Realization
        public SqlRepository() : this((new sBaseContextFactory()).CreateDbContext(null)) { }
        public SqlRepository(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        #endregion

        #region Interface's Methods
        #region IRepositiry

        public void Add<Entity>(Entity entity)
            where Entity : class,IDomainObject
        {
            var table = context.Set<Entity>();
            table.Add(entity);
            Save();
        }
        public void Add<Entity>(IList<Entity> entities)
            where Entity : class,IDomainObject
        {
            var table = context.Set<Entity>();
            table.AddRange(entities);
            Save();
        }
        public Entity GetById<Entity>(int id)
            where Entity : class,IDomainObject
        {
            var table = context.Set<Entity>();
            return table.Find(id);
        }
        public IEnumerable<Entity> Get<Entity>(int count, Expression<Func<Entity, bool>> predicate)
            where Entity : class,IDomainObject
        {
            var table = context.Set<Entity>();
            return table.Where(predicate).Take(count).ToList();
        }
        public IEnumerable<Entity> GetAll<Entity,TSortField>(Expression<Func<Entity, TSortField>> orderBy, bool ascending)
            where Entity : class,IDomainObject
        {
            var table = context.Set<Entity>();
            return ascending ? table.OrderBy(orderBy) : table.OrderByDescending(orderBy);
        }
        public void Remove<Entity>(Entity entity)
            where Entity : class,IDomainObject
        {
            context.Entry(entity).State = EntityState.Deleted;
            Save();
        }
        private void Save()
        {
            context.SaveChanges();
        }
        public void Save<Entity>(Entity entity)
            where Entity : class, IDomainObject

        {
            context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        #region async
        public async Task<bool> AddAsync<Entity>(Entity entity)
            where Entity : class, IDomainObject

        {
            var table = context.Set<Entity>();
            table.Add(entity);
            int state = await SaveAsync();
            if (Enum.IsDefined(typeof(EntityState), state) && (EntityState)state == EntityState.Added)
                return false;
            return true;
        }
        public async Task<bool> AddAsync<Entity>(IList<Entity> entities)    
            where Entity : class, IDomainObject
        {
            var table = context.Set<Entity>();
            table.AddRange(entities);
            int state = await SaveAsync();
            if (Enum.IsDefined(typeof(EntityState), state) && (EntityState)state == EntityState.Added)
                return true;
            else
                return false;
        }
        public async Task<Entity> GetByIdAsync<Entity>(int id)
            where Entity : class, IDomainObject
        {
            var table = context.Set<Entity>();
            return await table.FindAsync(id);
        }
        public async Task<IEnumerable<Entity>> GetAsync<Entity>(int count, Expression<Func<Entity, bool>> predicate)
            where Entity : class, IDomainObject
        {
            var table = context.Set<Entity>();
            return await table.Where(predicate).Take(count).ToListAsync();
        }
        public async Task<IEnumerable<Entity>> GetAllAsync<Entity,TSortField>(Expression<Func<Entity, TSortField>> orderBy, bool ascending)
            where Entity : class, IDomainObject
        {
            var table = context.Set<Entity>();
            return ascending ? await table.OrderBy(orderBy).ToListAsync() : await table.OrderByDescending(orderBy).ToListAsync();
        }
        public async Task<bool> RemoveAsync<Entity>(Entity entity)
            where Entity : class, IDomainObject
        {
            context.Entry(entity).State = EntityState.Deleted;
            int state = await SaveAsync();
            if (Enum.IsDefined(typeof(EntityState), state) && (EntityState)state == EntityState.Deleted)
                return false;
            return true;
        }
        private async Task<int> SaveAsync()
        {
            int state = 0;
            try
            {
                state = await context.SaveChangesAsync();
            }
            //TODO Сделать нормальную обработку исключений в SaveChange и SaveChangeAsync
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return state;
        }
        public async Task<bool> SaveAsync<Entity>(Entity entity)
            where Entity : class, IDomainObject
        {
            context.Entry(entity).State = EntityState.Modified;
            int state = await SaveAsync();
            if (Enum.IsDefined(typeof(EntityState), state) && (EntityState)state == EntityState.Modified)
                return false;
            return true;
        }

        public void Dispose()
        {
            context.Dispose();
            context = null;
        }
        #endregion

        #endregion

        #endregion

    }
}
