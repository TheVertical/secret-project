using Microsoft.EntityFrameworkCore;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models;
using SecretProject.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        #region Base Methods
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
        //TODO Переделать метод получения всех сущностей
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

        #endregion

        #region Special Methods

        #endregion
    }
}
