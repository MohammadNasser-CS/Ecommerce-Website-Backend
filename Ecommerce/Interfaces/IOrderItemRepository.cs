using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem?> GetOrderItemByIdAsync(int orderItemId);
        Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        Task<OrderItem?> UpdateOrderItemAsync(OrderItem orderItem);
        Task<OrderItem?> DeleteOrderItemAsync(int orderItemId);
    }
}
