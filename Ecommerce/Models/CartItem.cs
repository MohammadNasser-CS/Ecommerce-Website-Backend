using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Ecommerce.Models
{
    public class CartItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartItemId { get; set; }
        [Required] 
        [ForeignKey("Cart")] 
        public int CartId { get; set; }
        [Required] 
        [ForeignKey("Product")] 
        public int ProductId { get; set; }
        [Required] 
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
        [InverseProperty("CartItems"), DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; } 
    }
}
