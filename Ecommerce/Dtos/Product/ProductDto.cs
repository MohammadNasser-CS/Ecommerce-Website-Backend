using Ecommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public required string CategoryName { get; set; }
        public required int Stock { get; set; }
        public decimal Rating { get; set; }
        public int TotalSales { get; set; }
        public override string ToString()
        {
            return $"ProductId: {ProductId}, Name: {Name}, Price: {Price}, Description: {Description}, ImageUrl: {ImageUrl}, CategoryName: {CategoryName}, Rating: {Rating}, TotalSales: {TotalSales}";
        }
    }
}
