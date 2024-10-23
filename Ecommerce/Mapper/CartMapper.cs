using Ecommerce.Dtos.Cart;
using Ecommerce.Dtos.Product;
using Ecommerce.Models;

namespace Ecommerce.Mapper
{
    public static class CartMapper
    {
        public static CartDto ToCartDto(this Cart cart)
        {
            return new CartDto
            {
                CartId = cart.CartId,
                UserId = cart.UserId,
                TotalAmount = cart.TotalAmount,
                TotalItems = cart.TotalItems,
                CartItems = cart.CartItems.Select(ci => ci.ToCartItemDto()).ToList()
            };
        }

        public static Cart CreateCartDto(this CreateCartRequestDto dto)
        {
            return new Cart
            {
                UserId = dto.UserId,
                TotalAmount = dto.TotalAmount,
                TotalItems = dto.TotalItems,
                CartItems = dto.CartItems.Select(ci => ci.CreateCartItemDto()).ToList()
            };
        }
        public static void UpdateCartDto(this Cart cart, UpdateCartRequestDto cartDto)
        {
            cart.TotalAmount = cartDto.TotalAmount ?? cart.TotalAmount;
            cart.TotalItems = cartDto.TotalItems ?? cart.TotalItems;
            if (cartDto.CartItems != null)
            {
                cart.CartItems = cartDto.CartItems!.Select(c => new CartItem
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                }).ToList();
            }
        }
    }
}
