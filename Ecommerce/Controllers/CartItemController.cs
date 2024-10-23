using Ecommerce.Dtos.Cart;
using Ecommerce.Interfaces;
using Ecommerce.Mapper;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemController(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        [HttpGet("{cartItemId}")]
        public async Task<IActionResult> GetCartItemById(int cartItemId)
        {
            var cartItem = await _cartItemRepository.GetCartItemByIdAsync(cartItemId);
            if (cartItem == null)
                return NotFound();

            return Ok(new { Message = "success", cartItem = cartItem.ToCartItemDto() });
        }

        [HttpGet("cart/{cartId}")]
        public async Task<IActionResult> GetCartItemsByCartId(int cartId)
        {
            var cartItems = await _cartItemRepository.GetCartItemsByCartIdAsync(cartId);
            return Ok(new { Message = "success", cartItems = cartItems.Select(ci => ci.ToCartItemDto()) });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartItem([FromBody] CreateCartItemRequestDto cartItemDto)
        {
            var cartItem = cartItemDto.CreateCartItemDto();
            await _cartItemRepository.AddCartItemAsync(cartItem);
            return Ok(new { Message = "success", cartItem = cartItem.ToCartItemDto() });
        }

        [HttpPut("{cartItemId}")]
        public async Task<IActionResult> UpdateCartItem([FromRoute] int cartItemId, [FromBody] UpdateCartItemRequestDto cartItemDto)
        {
            var cartItem = await _cartItemRepository.GetCartItemByIdAsync(cartItemId);
            if (cartItem == null) return NotFound();
            cartItem.UpdateCartItemDto(cartItemDto);
            await _cartItemRepository.UpdateCartItemAsync(cartItem);
            return Ok(new { Message = "success", cartItem = cartItem.ToCartItemDto() });
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> DeleteCartItem(int cartItemId)
        {
            await _cartItemRepository.DeleteCartItemAsync(cartItemId);
            return NoContent();
        }
    }
}
