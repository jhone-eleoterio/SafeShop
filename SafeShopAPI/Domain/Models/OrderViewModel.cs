using System.ComponentModel.DataAnnotations;

namespace SafeShopAPI.Domain.Models
{
    public class OrderViewModel
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }

    public class OrderViewModelUpdate
    {
        [Required]
        public int Quantity { get; set; }
    }
}
