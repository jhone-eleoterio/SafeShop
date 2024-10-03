using Microsoft.EntityFrameworkCore;
using SafeShopAPI.Domain.Interfaces.Shared;

namespace SafeShopAPI.Data.Repository.Shared
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly SafeShopContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(SafeShopContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<TEntity> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
