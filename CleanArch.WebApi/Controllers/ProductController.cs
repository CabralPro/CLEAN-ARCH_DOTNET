using CleanArch.Application.Dtos;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, 
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            return await _productService.GetListAsync();
        }
    }
}