using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Order
{
    public class CreateOrderItemRequestDto
    {
        [Required(ErrorMessage = "The CartId field is required.")]
        public required int OrderId { get; set; }
        [Required(ErrorMessage = "The ProductId field is required.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "The Quantity field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price must be greater than 0.")]
        public decimal Price { get; set; }
    }
}
