using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model.Model;

namespace TestProject.Repository.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseModel
    {
        /// <summary>
        /// Create record.
        /// </summary>
        /// <param name="model">Record that need to create.</param>
        /// <returns>Newly created record.</returns>
        Task<TEntity> CreateAsync(TEntity model);

        /// <summary>
        /// Get all records.
        /// </summary>
        /// <returns></returns>
        Task<IList<TEntity>> GetAllAsync();

        /// <summary>
        /// Get specific record by <paramref name="id"/>. 
        /// </summary>
        /// <param name="id">Record id.</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(Int64 id);

        /// <summary>
        /// Get specific record by filteration 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<TEntity> ExistAsync(Expression<Func<TEntity, bool>> filter);
    }
}
