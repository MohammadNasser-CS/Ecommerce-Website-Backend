using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Ecommerce.Models
{
    public class Cart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        [Required] 
        [ForeignKey("User")]
        public required string UserId { get; set; }
        [Required] 
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be non-negative.")]
        public decimal TotalAmount { get; set; } 
        [Required] 
        [Range(0, int.MaxValue, ErrorMessage = "Total items must be a non-negative number.")]
        public int TotalItems { get; set; }
        [Required] 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual User User { get; set; }
        [InverseProperty("Cart")]
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
