using System.ComponentModel.DataAnnotations;

namespace SafeShopAPI.Domain.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
