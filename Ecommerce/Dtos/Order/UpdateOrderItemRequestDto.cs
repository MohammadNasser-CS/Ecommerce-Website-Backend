namespace Ecommerce.Dtos.Order
{
    public class UpdateOrderItemRequestDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
