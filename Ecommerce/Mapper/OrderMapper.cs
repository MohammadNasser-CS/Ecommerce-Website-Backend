using Ecommerce.Dtos.Cart;
using Ecommerce.Dtos.Order;
using Ecommerce.Models;

namespace Ecommerce.Mapper
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                TotalAmount = order.TotalAmount,
                TotalItems = order.TotalItems,
                OrderItems = order.OrderItems.Select(oi => oi.ToOrderItemDto()).ToList()
            };
        }

        public static Order CreateOrderDto(this CreateOrderRequestDto dto)
        {
            return new Order
            {
                UserId = dto.UserId,
                TotalAmount = dto.TotalAmount,
                TotalItems = dto.TotalItems,
                OrderItems = dto.OrderItems.Select(oi => oi.CreateOrderItemDto()).ToList(),
                BillingAddress = dto.BillingAddress,
                ShippingAddress = dto.ShippingAddress,
                Status = dto.Status,
                Notes = dto.Notes,
            };
        }
        public static void UpdateOrderDto(this Order order, UpdateOrderRequestDto orderDto)
        {
            order.TotalAmount = orderDto.TotalAmount ?? order.TotalAmount;
            order.TotalItems = orderDto.TotalItems ?? order.TotalItems;
            if (orderDto.OrderItems != null)
            {
                order.OrderItems = orderDto.OrderItems!.Select(c => new OrderItem
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                }).ToList();
            }
        }
    }
}
