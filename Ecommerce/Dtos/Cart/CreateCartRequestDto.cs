using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Cart
{
    public class CreateCartRequestDto
    {
        [Required(ErrorMessage = "The UserId field is required.")]
        public required string UserId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "The TotalAmount must be a non-negative number greater than 1.")]
        public decimal TotalAmount { get; set; }

        public int TotalItems { get; set; }

        public List<CreateCartItemRequestDto> CartItems { get; set; } = new List<CreateCartItemRequestDto>();
    }
}
