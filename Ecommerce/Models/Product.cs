using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Ecommerce.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required, Column(TypeName = "varchar"), MaxLength(50)]
        public required string Name { get; set; }
        [Required, Column(TypeName = "varchar"), MaxLength(500)]
        public required string Description { get; set; }
        [Required, Range(0.01, 10000.00)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Stock { get; set; }
        [Required, MaxLength(255)]
        public required string ImageUrl { get; set; }
        [Range(0, 5)]
        [Column(TypeName = "decimal(3, 2)")]
        public decimal Rating { get; set; }
        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }
        [Range(0, int.MaxValue)]
        public int TotalSales { get; set; }
        // Foreign key for Category
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [InverseProperty("Products"), AllowNull, DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Category Category { get; set; }
        public override string ToString()
        {
            return $"ProductId: {ProductId}, Name: {Name}, Price: {Price}, Description: {Description}, ImageUrl: {ImageUrl}, CategoryId: {CategoryId}, Rating: {Rating}, TotalSales: {TotalSales}";
        }
    }

}
