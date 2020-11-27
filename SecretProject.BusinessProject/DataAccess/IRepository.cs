using SecretProject.BusinessProject.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SecretProject.BusinessProject.DataAccess
{
    public interface IRepository
    {
        object GetById(int id);
        void Add(object entity);
        void Remove(object entity);
        void Update(object entity);
    }
    public interface IRepository<Entity>
        where Entity : class, IDomainObject
    {
        Entity GetById(int id);
        IEnumerable<Entity> Get(int count, Func<Entity, bool> pericate);
        //TODO Переделать метод получения всех сущностей в интерфейсе!
        IEnumerable<Entity> GetAll<TSortField>(Expression<Func<Entity, TSortField>> orderBy, bool ascending);
        void Add(Entity entity);
        void Remove(Entity entity);
        void Update(Entity entity);
        void Save(Entity entity);
    }
}
