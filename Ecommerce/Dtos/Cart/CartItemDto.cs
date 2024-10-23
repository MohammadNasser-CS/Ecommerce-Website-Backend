namespace Ecommerce.Dtos.Cart
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }
        public required int CartId { get; set; }
        public required int ProductId { get; set; }
        public required int Quantity { get; set; }
    }
}
