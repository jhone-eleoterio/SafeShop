namespace SafeShopAPI.Domain.Interfaces.Shared
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task DeleteByIdAsync(Guid id);
    }
}
