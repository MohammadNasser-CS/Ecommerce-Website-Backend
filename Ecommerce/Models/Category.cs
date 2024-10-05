using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Ecommerce.Models
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required, MaxLength(100)]
        public required string Name { get; set; }
        [AllowNull, MaxLength(500)]
        public string Description { get; set; }
        [Required, MaxLength(255)]
        public required string ImageUrl { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
