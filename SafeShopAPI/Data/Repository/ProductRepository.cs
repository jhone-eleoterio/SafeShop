using Microsoft.EntityFrameworkCore;
using SafeShopAPI.Data.Repository.Shared;
using SafeShopAPI.Domain.Entities;
using SafeShopAPI.Domain.Interfaces;

namespace SafeShopAPI.Data.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(SafeShopContext context)
            : base(context) { }
    }
}
