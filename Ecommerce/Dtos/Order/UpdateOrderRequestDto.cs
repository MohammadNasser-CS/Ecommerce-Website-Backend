namespace Ecommerce.Dtos.Order
{
    public class UpdateOrderRequestDto
    {
        public decimal? TotalAmount { get; set; }
        public int? TotalItems { get; set; }
        public List<UpdateOrderItemRequestDto>? OrderItems { get; set; }
        public string? BillingAddress { get; set; }
        public string? ShippingAddress { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
    }
}
