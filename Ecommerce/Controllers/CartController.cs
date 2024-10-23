using Ecommerce.Dtos.Cart;
using Ecommerce.Interfaces;
using Ecommerce.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCartByUserId([FromRoute] string userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null) return NotFound();
            return Ok(new { Message = "success", cart = cart.ToCartDto() });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartRequestDto createCart)
        {
            var cart = createCart.CreateCartDto();
            await _cartRepository.CreateCartAsync(cart);
            return CreatedAtAction(nameof(GetCartByUserId), new { userId = cart.UserId }, new { Message = "success", cart = cart.ToCartDto() });
        }

        [HttpPut("{cartId}")]
        public async Task<IActionResult> UpdateCart([FromRoute] int cartId, [FromBody] UpdateCartRequestDto updateCart)
        {
            var cart = await _cartRepository.GetCartByIdAsync(cartId);
            if (cart == null) return NotFound();
            cart.UpdateCartDto(updateCart);

            await _cartRepository.UpdateCartAsync(cart);
            return Ok(new { Message = "success", cart = cart.ToCartDto() });
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> DeleteCart(int cartId)
        {
            var cartExists = await _cartRepository.CartExistsAsync(cartId);
            if (!cartExists) return NotFound();

            await _cartRepository.DeleteCartAsync(cartId);
            return NoContent();
        }
    }
}

