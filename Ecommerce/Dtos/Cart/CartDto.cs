namespace Ecommerce.Dtos.Cart
{
    public class CartDto
    {
        public int CartId { get; set; }

        public string UserId { get; set; }

        public decimal TotalAmount { get; set; }

        public int TotalItems { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();
    }
}
