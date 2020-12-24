using SecretProject.BusinessProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SecretProject.BusinessProject.DataAccess
{
    public interface IQueryableRepository
    {
        IQueryable<Entity> Get<Entity>(int count, Expression<Func<Entity, bool>> pericate) where Entity : class, IDomainObject;
        IQueryable<Entity> GetAll<Entity, TSortField>(Expression<Func<Entity, TSortField>> orderBy, bool ascending) where Entity : class, IDomainObject;
        void Add<Entity>(Entity entity) where Entity : class, IDomainObject;
        void Remove<Entity>(Entity entity) where Entity : class, IDomainObject;
        void Save<Entity>(Entity entity) where Entity : class, IDomainObject;
        Task<Entity> GetByIdAsync<Entity>(int id) where Entity : class, IDomainObject;
        Task<IQueryable<Entity>> GetAsync<Entity>(int count, Expression<Func<Entity, bool>> pericate) where Entity : class, IDomainObject;
        Task<IQueryable<Entity>> GetAllAsync<Entity, TSortField>(Expression<Func<Entity, TSortField>> orderBy, bool ascending) where Entity : class, IDomainObject;
        Task<bool> AddAsync<Entity>(Entity entity) where Entity : class, IDomainObject;
        Task<bool> RemoveAsync<Entity>(Entity entity) where Entity : class, IDomainObject;
        Task<bool> SaveAsync<Entity>(Entity entity) where Entity : class, IDomainObject;
    }
    public interface IRepository
    {
        IEnumerable<Entity> Get<Entity>(int count, Expression<Func<Entity, bool>> pericate) where Entity : class, IDomainObject;
        IEnumerable<Entity> GetAll<Entity,TSortField>(Expression<Func<Entity, TSortField>> orderBy, bool ascending) where Entity : class, IDomainObject;
        void Add<Entity>(Entity entity) where Entity : class,IDomainObject;
        void Remove<Entity>(Entity entity) where Entity : class,IDomainObject;
        void Save<Entity>(Entity entity) where Entity : class,IDomainObject;
        Task<Entity> GetByIdAsync<Entity>(int id) where Entity : class,IDomainObject;
        Task<IEnumerable<Entity>> GetAsync<Entity>(int count, Expression<Func<Entity, bool>> pericate) where Entity : class, IDomainObject;
        Task<IEnumerable<Entity>> GetAllAsync<Entity, TSortField>(Expression<Func<Entity, TSortField>> orderBy, bool ascending) where Entity : class, IDomainObject;
        Task<bool> AddAsync<Entity>(Entity entity) where Entity : class,IDomainObject;
        Task<bool> RemoveAsync<Entity>(Entity entity) where Entity : class,IDomainObject;
        Task<bool> SaveAsync<Entity>(Entity entity) where Entity : class,IDomainObject;

    }
    public interface IRepository<Entity>
        where Entity : class, IDomainObject
    {
        Entity GetById(int id);
        IEnumerable<Entity> Get(int count,Expression<Func<Entity, bool>> pericate);
        //TODO Переделать метод получения всех сущностей в интерфейсе!
        IEnumerable<Entity> GetAll<TSortField>(Expression<Func<Entity, TSortField>> orderBy, bool ascending);
        void Add(Entity entity);
        void Remove(Entity entity);
        void Save(Entity entity);

        Task<Entity> GetByIdAsync(int id);
        Task<IEnumerable<Entity>> GetAsync(int count, Expression<Func<Entity, bool>> pericate);
        Task<IEnumerable<Entity>> GetAllAsync<TSortField>(Expression<Func<Entity, TSortField>> orderBy, bool ascending);
        Task<bool> AddAsync(Entity entity);
        Task<bool> RemoveAsync(Entity entity);
        Task<bool> SaveAsync(Entity entity);
    }
}
