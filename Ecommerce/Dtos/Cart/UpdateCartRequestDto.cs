using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Dtos.Cart
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateCartRequestDto : ControllerBase
    {
        public decimal? TotalAmount { get; set; }
        public int? TotalItems { get; set; }
        public List<UpdateCartItemRequestDto>? CartItems { get; set; }= new List<UpdateCartItemRequestDto>();
    }
}
