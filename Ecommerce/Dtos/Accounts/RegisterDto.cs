using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Accounts
{
    public class RegisterDto
    {
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
