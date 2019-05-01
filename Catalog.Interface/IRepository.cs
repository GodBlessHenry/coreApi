using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Catalog.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Handler - Add entity(ies).
        /// </summary>
        void Add(TEntity entity);

        /// <summary>
        /// Handler - Delete entity and/or criteria
        /// </summary>
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> criteria);

        /// <summary>
        /// Handler - Find a collection of entities based of the passed in predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Handler - Retrieve entity by key value.
        /// </summary>
        /// <param name="value">Value</param>
        TEntity Get(object value);

        /// <summary>
        /// Handler - Retrieve entities.
        /// </summary>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Handler - Retrieve the query.
        /// </summary>
        IQueryable<TEntity> GetQuery();

        /// <summary>
        /// Handler - Retrieve the query.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Handler - Update entity(ies).
        /// </summary>
        void Update(TEntity entity);
    }
}
