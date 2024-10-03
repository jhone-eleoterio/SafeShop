using SafeShopAPI.Domain.Entities;
using SafeShopAPI.Domain.Interfaces.Shared;

namespace SafeShopAPI.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmailAsync(string email);
    }
}
