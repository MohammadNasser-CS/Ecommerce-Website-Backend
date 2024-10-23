using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Ecommerce.Enums;

namespace Ecommerce.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }  

        [Required] 
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than 0.")]
        public decimal TotalAmount { get; set; } 
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Total items must be at least 1.")]
        public int TotalItems { get; set; } 

        [Required] 
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(50)]
        public required string Status { get; set; } = OrderStatus.Pending.ToString(); // (Pending, Shipped, Delivered)
        [AllowNull]
        [MaxLength(500)] 
        public string? Notes { get; set; } 
        [Required] 
        [MaxLength(250)] 
        public required string ShippingAddress { get; set; }
        [Required]
        [MaxLength(250)] 
        public required string BillingAddress { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        [InverseProperty("Orders")]
        public virtual User User { get; set; } 

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
