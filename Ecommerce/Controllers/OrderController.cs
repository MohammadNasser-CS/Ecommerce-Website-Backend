using Ecommerce.Dtos.Order;
using Ecommerce.Interfaces;
using Ecommerce.Mapper;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<OrderDto>>> GetOrdersByUserId(string userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return Ok(new { Message = "success", orders = orders.Select(o => o.ToOrderDto()).ToList() });
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(CreateOrderRequestDto createOrder)
        {
            var order = createOrder.CreateOrderDto();
            await _orderRepository.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrdersByUserId), new { userId = order.UserId }, new { Message = "success", order = order.ToOrderDto() });
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int orderId, UpdateOrderRequestDto updateOrder)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null) return NotFound();

            order.UpdateOrderDto(updateOrder);

            await _orderRepository.UpdateOrderAsync(order);
            return Ok(new { Message = "success", cart = order.ToOrderDto() });
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null) return NotFound();

            await _orderRepository.DeleteOrderAsync(orderId);
            return NoContent();
        }
    }
}
