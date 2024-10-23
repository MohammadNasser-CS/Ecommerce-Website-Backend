using Ecommerce.Dtos.Cart;
using Ecommerce.Dtos.Order;
using Ecommerce.Interfaces;
using Ecommerce.Mapper;
using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {

        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemController(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        [HttpGet("{orderItemId}")]
        public async Task<IActionResult> GetOrderItemById(int orderItemId)
        {
            var orderItem = await _orderItemRepository.GetOrderItemByIdAsync(orderItemId);
            if (orderItem == null)
                return NotFound();

            return Ok(new { Message = "success", orderItem = orderItem.ToOrderItemDto() });

        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetOrderItemsByOrderId(int orderId)
        {
            var orderItems = await _orderItemRepository.GetOrderItemsByOrderIdAsync(orderId);
            return Ok(new { Message = "success", orderItems = orderItems.Select(oi=>oi.ToOrderItemDto())});
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderItem([FromBody]  CreateOrderItemRequestDto orderItemDto)
        {
            var orderItem = orderItemDto.CreateOrderItemDto();
            await _orderItemRepository.AddOrderItemAsync(orderItem);
            return CreatedAtAction(nameof(GetOrderItemById), new { orderItemId = orderItem.OrderItemId }, new { Message = "success", orderItem = orderItem.ToOrderItemDto() });
        }

        [HttpPut("{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItem(int orderItemId,[FromBody] UpdateOrderItemRequestDto orderItemDto)
        {
            var orderItem = await _orderItemRepository.GetOrderItemByIdAsync(orderItemId);
            if (orderItem == null) return NotFound();
            orderItem.UpdateCartItemDto(orderItemDto);
            await _orderItemRepository.UpdateOrderItemAsync(orderItem);
            return Ok(new { Message = "success", orderItem = orderItem.ToOrderItemDto() });
        }

        [HttpDelete("{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItem(int orderItemId)
        {
            await _orderItemRepository.DeleteOrderItemAsync(orderItemId);
            return NoContent();
        }
    }
}
