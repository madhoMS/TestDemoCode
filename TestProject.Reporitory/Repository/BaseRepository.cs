using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model.Model;
using TestProject.Repository.Context;
using TestProject.Repository.IRepository;

namespace TestProject.Repository.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseModel
    {
        #region Fields
        private readonly TestDbContext _dbContext;
        #endregion

        #region Constructor
        public BaseRepository(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        /// <summary>
        /// Create record.
        /// </summary>
        /// <param name="model">Record that need to create.</param>
        /// <returns>Newly created record.</returns>
        public async Task<TEntity> CreateAsync(TEntity model)
        {
            await _dbContext.AddAsync<TEntity>(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        /// <summary>
        /// Get specific record by filteration 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<TEntity> ExistAsync(Expression<Func<TEntity, bool>> filter)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking().AsQueryable();
            return await query.FirstOrDefaultAsync(filter);
        }

        /// <summary>
        /// Get all records.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Get specific record by <paramref name="id"/>. 
        /// </summary>
        /// <param name="id">Record id.</param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbContext.FindAsync<TEntity>(id);
        }


    }
}
