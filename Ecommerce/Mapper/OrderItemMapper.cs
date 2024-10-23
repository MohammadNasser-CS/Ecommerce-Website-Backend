using Ecommerce.Dtos.Cart;
using Ecommerce.Dtos.Order;
using Ecommerce.Models;

namespace Ecommerce.Mapper
{
    public static class OrderItemMapper
    {
        public static OrderItemDto ToOrderItemDto(this OrderItem orderItem)
        {
            return new OrderItemDto
            {
                OrderItemId = orderItem.OrderItemId,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
                Price = orderItem.Price
            };
        }

        public static OrderItem CreateOrderItemDto(this CreateOrderItemRequestDto dto)
        {
            return new OrderItem
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                Price = dto.Price
            };
        }
        public static void UpdateCartItemDto(this OrderItem orderItem, UpdateOrderItemRequestDto dto)
        {
            orderItem.ProductId = dto.ProductId;
            orderItem.Quantity = dto.Quantity;

        }
    }
}
