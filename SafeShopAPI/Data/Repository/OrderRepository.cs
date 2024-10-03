using Microsoft.EntityFrameworkCore;
using SafeShopAPI.Data.Repository.Shared;
using SafeShopAPI.Domain.Entities;
using SafeShopAPI.Domain.Interfaces;

namespace SafeShopAPI.Data.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(SafeShopContext context)
            : base(context) { }
    }
}
