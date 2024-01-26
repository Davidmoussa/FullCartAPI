using FullCartApp.Application.Contracts.Contracts;
using FullCartApp.Application.Contracts.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        public CategoryController( ICategoryService categoryService)
        {
           
            _categoryService = categoryService;
        }


        [HttpPost("AddOrUpdate")]
        public IActionResult AddOrUpdate(CategoryVM category)
        {
           return Ok(_categoryService.AddOrUpdate(category));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int Id )
        {
            return Ok(_categoryService.GetById(Id));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            return Ok(_categoryService.Delete(Id));
        }
    }
}
