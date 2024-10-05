using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Models
{
    public class User : IdentityUser
    {
        [Required, Column(TypeName = "varchar"), MaxLength(20)]
        public required string FirstName { get; set; }
        [Required, Column(TypeName = "varchar"), MaxLength(20)]
        public required string LastName { get; set; }
    }
}
