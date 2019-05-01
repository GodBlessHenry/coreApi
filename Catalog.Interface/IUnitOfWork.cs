using System;

namespace Catalog.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Handler - Cancel pending changes.
        /// </summary>
        void Abort();

        /// <summary>
        /// Handler - Commit pending changes.
        /// </summary>
        /// <returns></returns>
        int Complete();

        /// <summary>
        /// Handler - Retrieve repository instance of TEntity.
        /// </summary>
        /// <typeparam name="TEntity">Class of type TEntity</typeparam>
        /// <returns>IRepository of TEntity</returns>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
