using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Order
{
    public class CreateOrderRequestDto
    {
        [Required(ErrorMessage = "The TotalAmount field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The TotalAmount must be greater than 0.")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "The TotalItems field is required.")]
        public int TotalItems { get; set; }

        [Required(ErrorMessage = "The OrderDate field is required.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "The Status field is required.")]
        public string Status { get; set; }

        [MaxLength(500, ErrorMessage = "The Notes field must be a maximum of 500 characters.")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "The ShippingAddress field is required.")]
        public string ShippingAddress { get; set; }

        [Required(ErrorMessage = "The BillingAddress field is required.")]
        public string BillingAddress { get; set; }

        [Required(ErrorMessage = "The UserId field is required.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "The OrderItems field is required.")]
        public List<CreateOrderItemRequestDto> OrderItems { get; set; } = new List<CreateOrderItemRequestDto>();

    }
}
