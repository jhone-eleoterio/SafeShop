using Microsoft.EntityFrameworkCore;
using SafeShopAPI.Domain.Entities;

namespace SafeShopAPI.Data
{
    public class SafeShopContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public SafeShopContext(DbContextOptions<SafeShopContext> dbContext) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("SafeShopDb");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Product>()
                .HasData(
                    new(
                        id: Guid.Parse("1bcfa457-7a57-418b-bd1c-75a3db9e4fa9"),
                        name: "Laptop Pro",
                        description: "High-end laptop with 16GB RAM and 512GB SSD",
                        price: 1500,
                        promoPrice: 1200
                    ),
                    new(
                        id: Guid.Parse("863fccae-c502-4001-b23d-f006c1cd3323"),
                        name: "Wireless Mouse",
                        description: "Ergonomic wireless mouse with adjustable DPI",
                        price: 50,
                        promoPrice: 40
                    ),
                    new(
                        id: Guid.Parse("c9dcbd5e-c5b7-4a6d-b733-acfd08108998"),
                        name: "Mechanical Keyboard",
                        description: "RGB mechanical keyboard with blue switches",
                        price: 100,
                        promoPrice: null
                    ),
                    new(
                        id: Guid.Parse("e9b006bd-b69d-4e8c-bf74-b1601eb1d79e"),
                        name: "4K Monitor",
                        description: "27-inch 4K Ultra HD monitor with HDR support",
                        price: 350,
                        promoPrice: 300
                    ),
                    new(
                        id: Guid.Parse("352037ad-0fb7-4c91-a66c-2106ae3afcb8"),
                        name: "Noise Cancelling Headphones",
                        description: "Over-ear headphones with active noise cancellation",
                        price: 200,
                        promoPrice: null
                    )
                );

            modelBuilder
                .Entity<Order>()
                .HasData(
                    new Order(
                        numberOrder: "1001",
                        productId: Guid.Parse("1bcfa457-7a57-418b-bd1c-75a3db9e4fa9"),
                        quantity: 2
                    ),
                    new Order(
                        numberOrder: "1002",
                        productId: Guid.Parse("863fccae-c502-4001-b23d-f006c1cd3323"),
                        quantity: 5
                    ),
                    new Order(
                        numberOrder: "1003",
                        productId: Guid.Parse("c9dcbd5e-c5b7-4a6d-b733-acfd08108998"),
                        quantity: 3
                    ),
                    new Order(
                        numberOrder: "1004",
                        productId: Guid.Parse("352037ad-0fb7-4c91-a66c-2106ae3afcb8"),
                        quantity: 1
                    ),
                    new Order(
                        numberOrder: "1005",
                        productId: Guid.Parse("352037ad-0fb7-4c91-a66c-2106ae3afcb8"),
                        quantity: 4
                    )
                );

            modelBuilder
                .Entity<User>()
                .HasData(
                    new User(
                        userName: "batman",
                        firstName: "Bruce",
                        lastName: "Wayne",
                        email: "bruce@gmail.com",
                        password: "123"
                    )
                );
        }
    }
}
