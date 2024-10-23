using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Cart
{
    public class CreateCartItemRequestDto
    {
        [Required(ErrorMessage = "The CartId field is required.")]
        public required int CartId { get; set; }
        [Required(ErrorMessage = "The ProductId field is required.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "The Quantity field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}
