namespace Ecommerce.Dtos.Order
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public decimal TotalAmount { get; set; }

        public int TotalItems { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; }

        public string? Notes { get; set; }

        public string ShippingAddress { get; set; }

        public string BillingAddress { get; set; }

        public string UserId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
