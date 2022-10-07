using CleanArch.Application.Dtos;
using CleanArch.Application.Interfaces;
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
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
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
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Post([FromBody] ProductDto productDto)
        {
            try
            {
                await _productService.Add(productDto);
                return OkResponse();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error create product : {ex.Message}; InnerExeption : {ex.InnerException}");
                return ErrorResponse(ex);
            }
        }        

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Put([FromBody] ProductDto productDto)
        {
            try
            {
                await _productService.Update(productDto);
                return OkResponse();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error update product : {ex.Message}; InnerExeption : {ex.InnerException}");
                return ErrorResponse(ex);
            }
        }

        [HttpDelete]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Delete([FromQuery] Guid id)
        {
            try
            {
                await _productService.Remove(id);
                return OkResponse();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error delete product : {ex.Message}; InnerExeption : {ex.InnerException}");
                return ErrorResponse(ex);
            }
        }


        [HttpGet("list")]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
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