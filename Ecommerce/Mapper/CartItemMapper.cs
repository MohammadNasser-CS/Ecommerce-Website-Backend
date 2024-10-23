using Ecommerce.Dtos.Cart;
using Ecommerce.Models;

namespace Ecommerce.Mapper
{
    public static class CartItemMapper
    {
        public static CartItemDto ToCartItemDto(this CartItem cartItem)
        {
            return new CartItemDto
            {
                CartItemId = cartItem.CartItemId,
                CartId = cartItem.CartId,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
            };
        }

        public static CartItem CreateCartItemDto(this CreateCartItemRequestDto createCart)
        {
            return new CartItem
            {
                CartId = createCart.CartId,
                ProductId = createCart.ProductId,
                Quantity = createCart.Quantity,
            };
        }
        public static void UpdateCartItemDto(this CartItem cartItem, UpdateCartItemRequestDto cartItemDto)
        {
            cartItem.ProductId = cartItemDto.ProductId;
            cartItem.Quantity = cartItemDto.Quantity;

        }
    }
}
