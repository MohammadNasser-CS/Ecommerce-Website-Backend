namespace Ecommerce.Dtos.Order
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }
        public required int OrderId { get; set; }
        public required int ProductId { get; set; }
        public required int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
