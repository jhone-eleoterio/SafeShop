namespace SafeShopAPI.Domain.Entities
{
    public class Product : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? PromoPrice { get; set; }

        //TODO: add new property image =)
        //public string Image { get; set; }

        protected Product()
            : base() { }

        public Product(
            Guid? id,
            string? name,
            string? description,
            decimal price,
            decimal? promoPrice
        )
        {
            Id = id.HasValue ? id.Value : Guid.NewGuid();
            Name = !string.IsNullOrEmpty(name) ? name : string.Empty;
            Description = !string.IsNullOrEmpty(description) ? description : string.Empty;
            Price = price;
            PromoPrice = promoPrice.HasValue ? promoPrice.Value : 0;
        }

        public void Update(string? name, string? description, decimal price, decimal? promoPrice)
        {
            Name = !string.IsNullOrEmpty(name) ? name : string.Empty;
            Description = !string.IsNullOrEmpty(description) ? description : string.Empty;
            Price = price;
            PromoPrice = promoPrice.HasValue ? promoPrice.Value : 0;
        }
    }
}
