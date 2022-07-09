
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }



        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            return Ok(await this.productService.GetProductsAsync());
        }

        [HttpGet("{productId}")]

        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {
            var result = await productService.GetProductAsync(productId);

            return Ok(result);
        }
    }
}
