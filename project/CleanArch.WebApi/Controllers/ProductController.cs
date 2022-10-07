using CleanArch.Application.Dtos;
using CleanArch.Application.Interfaces;
using CleanArch.WebApi.Controllers.ResponseTypes;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(
            ILogger<ProductController> logger,
            IProductService productService)
            : base(logger)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetById([FromQuery] Guid id)
        {
            try
            {
                var products = await _productService.GetByIdAsync(id);
                return ContentResponse(products);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error get product by id '{id}' : {ex.Message}; InnerExeption : {ex.InnerException}");
                return ErrorResponse(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
        public async Task<ActionResult> Post([FromBody] ProductDto productDto)
        {
            try
            {
                var productResult = await _productService.Add(productDto);
                return CreateResponse(productResult);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error create product : {ex.Message}; InnerExeption : {ex.InnerException}");
                return ErrorResponse(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<ActionResult> Put([FromBody] ProductDto productDto)
        {
            try
            {
                var productResult = await _productService.Update(productDto);
                return ContentResponse(productResult);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error update product : {ex.Message}; InnerExeption : {ex.InnerException}");
                return ErrorResponse(ex);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([FromQuery] Guid id)
        {
            try
            {
                await _productService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error delete product : {ex.Message}; InnerExeption : {ex.InnerException}");
                return ErrorResponse(ex);
            }
        }

        [HttpGet("list")]
        [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetList()
        {
            try
            {
                var products = await _productService.GetListAsync();
                return ContentResponse(products);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error listing products : {ex.Message}; InnerExeption : {ex.InnerException}");
                return ErrorResponse(ex);
            }
        }

    }
}