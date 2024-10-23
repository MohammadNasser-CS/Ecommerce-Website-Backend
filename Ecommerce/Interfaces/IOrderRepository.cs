using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order?> GetOrderByIdAsync(int orderId);
        public Task<List<Order>> GetOrdersByUserIdAsync(string userId);
        public Task<Order> CreateOrderAsync(Order order);
        public Task<Order?> UpdateOrderAsync(Order order);
        public Task<Order?> DeleteOrderAsync(int orderId);
    }
}
