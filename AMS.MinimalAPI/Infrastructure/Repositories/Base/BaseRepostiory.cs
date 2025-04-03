using AMS.MinimalAPI.Domain.Interface.Base;
using AMS.MinimalAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AMS.MinimalAPI.Infrastructure.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _appContext;
        protected BaseRepository() => _appContext = new AppDbContext();

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            var getAllAsync = await _appContext.Set<T>().AsNoTracking().ToListAsync();
            return getAllAsync;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            var getByIdAsync = await _appContext.Set<T>().FindAsync(id);
            return getByIdAsync;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _appContext.Set<T>().AddAsync(entity);
            var createAsync = await _appContext.SaveChangesAsync() > 0;

            return createAsync ? entity : null;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _appContext.Entry(entity).State = EntityState.Modified;
            var updateAsync = await _appContext.SaveChangesAsync() > 0;

            return updateAsync ? entity : null;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            //_appContext.Set<T>().Remove(entity);
            var deleteAsync = await _appContext.SaveChangesAsync() > 0;

            return deleteAsync;
        }
    }
}
