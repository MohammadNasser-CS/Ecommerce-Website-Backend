using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    public interface ICartRepository
    {
        public Task<Cart?> GetCartByIdAsync(int cartId);
        public Task<Cart?> GetCartByUserIdAsync(string userId);
        public Task<Cart> CreateCartAsync(Cart cart);
        public Task<Cart?> UpdateCartAsync(Cart cart);
        public Task<Cart?> DeleteCartAsync(int cartId);
        Task<bool> CartExistsAsync(int cartId);
    }
}
