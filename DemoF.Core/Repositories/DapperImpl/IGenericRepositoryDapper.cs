using DemoF.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoF.Core.Repositories
{
    /// <summary>
    /// Common operations for domain models
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepositoryDapper<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);

        TEntity Add(TEntity entity);
        Task<TEntity> AddAsyn(TEntity t);

        Task<TEntity> UpdateAsyn(IUpdatableModel t, object key);
        Task<int> DeleteAsyn(TEntity entity);

    }
}
