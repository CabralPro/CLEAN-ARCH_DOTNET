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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductDto>> GetById([FromQuery] Guid id)
        {
            var products = await _productService.GetByIdAsync(id);
            return ContentResponse(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductDto>> Post([FromBody] ProductDto productDto)
        {
            var productResult = await _productService.Add(productDto);
            return CreateResponse(productResult);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductDto>> Put([FromBody] ProductDto productDto)
        {
            var productResult = await _productService.Update(productDto);
            return UpdateResponse(productResult);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([FromQuery] Guid id)
        {
            await _productService.Remove(id);
            return Ok();
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductDto>>> GetList()
        {
            var products = await _productService.GetListAsync();
            return ContentResponse(products);
        }

    }
}