using FullCartApp.Application.Contracts.Contracts;
using FullCartApp.Application.Contracts.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {

            _orderService = orderService;
        }


        [HttpPost("AddOrUpdate")]
        public IActionResult AddOrUpdate(OrderVM order)
        {
            return Ok(_orderService.AddOrUpdate(order));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_orderService.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            return Ok(_orderService.GetById(Id));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            return Ok(_orderService.Delete(Id));
        }
    }
}
