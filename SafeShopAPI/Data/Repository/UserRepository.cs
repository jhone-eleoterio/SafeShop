using Microsoft.EntityFrameworkCore;
using SafeShopAPI.Data.Repository.Shared;
using SafeShopAPI.Domain.Entities;
using SafeShopAPI.Domain.Interfaces;

namespace SafeShopAPI.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SafeShopContext context)
            : base(context) { }

        public async Task<User> FindByEmailAsync(string email) =>
            await _dbSet.FirstOrDefaultAsync(_ => _.Email == email);
    }
}
