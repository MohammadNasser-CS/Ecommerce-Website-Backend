using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    public interface ICartItemRepository
    {
        public Task<CartItem?> GetCartItemByIdAsync(int cartItemId);
        public Task<List<CartItem>> GetCartItemsByCartIdAsync(int cartId);
        public Task<CartItem> AddCartItemAsync(CartItem cartItem);
        public Task<CartItem?> UpdateCartItemAsync(CartItem cartItem);
        public Task<CartItem?> DeleteCartItemAsync(int cartItemId);
    }
}
