using System.ComponentModel.DataAnnotations;

namespace SafeShopAPI.Domain.Entities
{
    public class User : Entity
    {
        protected User() { }

        public string? UserName { get; }
        public string? FirstName { get; }
        public string? LastName { get; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public User(
            string userName,
            string firstName,
            string lastName,
            string email,
            string password
        )
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
