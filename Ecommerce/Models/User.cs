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
        [InverseProperty("User")]
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        [InverseProperty("User")]
        public virtual Cart Cart { get; set; }
    }
}
