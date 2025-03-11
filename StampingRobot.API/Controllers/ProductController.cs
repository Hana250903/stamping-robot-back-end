using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StamingRobot.Repository.Commons;
using StampingRobot.API.ViewModels.RequestModels;
using StampingRobot.API.ViewModels.ResponseModels;
using StampingRobot.Service.BussinessModels;
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
        [Authorize]
        public async Task<IActionResult> GetProductsPaging([FromQuery] PaginationParameter paginationParameter, [FromQuery] FilterProduct filterProduct)
        {
            try
            {
                var result = await _productService.GetProducts(paginationParameter, filterProduct);
                if(result == null)
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "List product is empty"
                    });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var result = await _productService.GetProductById(id);
                if (result == null)
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Product not found"
                    });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequestModel productRequestModel)
        {
            try
            {
                ProductModel productModel = new ProductModel()
                {
                    Name = productRequestModel.Name,
                    Dimensions = productRequestModel.Dimensions,
                    Material = productRequestModel.Material,
                    StampId = productRequestModel.StampId,
                };

                var result = await _productService.CreateProduct(productModel);
                if (result)
                {
                    return Ok(new ResponseModel
                    {
                         HttpCode = StatusCodes.Status200OK,
                         Message = "Create successfully"
                    });
                }
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = "Create failed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestModel productRequestModel)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Product not found"
                    });
                }

                ProductModel productModel = new ProductModel()
                {
                    Id = id,
                    Name = productRequestModel.Name,
                    Dimensions = productRequestModel.Dimensions,
                    Material = productRequestModel.Material,
                    StampId = productRequestModel.StampId,
                };

                var result = await _productService.UpdateProduct(productModel);
                if (result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Update successfully"
                    });
                }
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = "Update failed"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var result = await _productService.DeleteProduct(id);

                if(result)
                {
                    return Ok(new ResponseModel
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Delete successfully"
                    });
                }
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = "Detele failed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }
}
