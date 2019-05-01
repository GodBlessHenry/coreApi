using Catalog.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Catalog.EFRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> criteria)
        {
            var records = GetQuery().Where(criteria);
            foreach (var record in records)
                Delete(record);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return GetQuery(predicate).AsEnumerable();
        }

        public TEntity Get(object value)
        {
            return _context.Find<TEntity>(value);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return GetQuery().AsEnumerable();
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return GetQuery().Where(predicate);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Update(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
