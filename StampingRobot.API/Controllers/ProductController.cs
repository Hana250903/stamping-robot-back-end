using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StamingRobot.Repository.Commons;
using StampingRobot.Service.Services;
using StampingRobot.Service.Services.Interface;

namespace StampingRobot.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsPaging([FromQuery] PaginationParameter paginationParameter)
        {
            var result = await _productService.GetProducts();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> CreateProduct()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<IActionResult> UpdateProduct(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
