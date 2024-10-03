using System.ComponentModel.DataAnnotations;

namespace SafeShopAPI.Domain.Models
{
    public class ProductViewModel
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? PromoPrice { get; set; }
    }
}
