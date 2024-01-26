using FullCartApp.Application.Contracts.Contracts;
using FullCartApp.Application.Contracts.ViewModels;
using FullCartApp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
     
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            
            _productService = productService;
        }


        [HttpPost("AddOrUpdate")]
        public IActionResult AddOrUpdate(ProductVM productVM)
        {
            return Ok(_productService.AddOrUpdate(productVM));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            return Ok(_productService.GetById(Id));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            return Ok(_productService.Delete(Id));
        }
    }
}
