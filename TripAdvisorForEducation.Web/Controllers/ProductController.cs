using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.ViewModels;
using TripAdvisorForEducation.Services;

namespace TripAdvisorForEducation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) => 
            _productService = productService;

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync() => 
            Json((await _productService.GetProductsAsync()).ToList());

        [HttpGet("{productId:guidid}")]
        public async Task<IActionResult> GetProductAsync([FromRoute]string productId) => 
            Json(await _productService.GetProductAsync(productId));

        [HttpGet("reviews/{productId:guidid}")]
        public async Task<IActionResult> GetProductReviewsAsync([FromRoute]string productId) => 
            Json((await _productService.GetProductReviewsAsync(productId)).ToList());

        [HttpGet("company/{productId:guidid}")]
        public async Task<IActionResult> GetProductCompanyAsync([FromRoute]string productId) => 
            Json(await _productService.GetProductCompanyAsync(productId));

        [HttpGet("categories/{productId:guidid}")]
        public async Task<IActionResult> GetProductCategoriesAsync([FromRoute]string productId) => 
            Json((await _productService.GetProductCategoriesAsync(productId)).ToList());

        [HttpPost("new")]
        public async Task<IActionResult> AddProductAsync([FromBody]ProductViewModel productViewModel)
        {
            var (success, productId) = await _productService.AddProductAsync(productViewModel);
            return success ? Ok(new { productID = productId }) : (IActionResult)BadRequest();
        }

        [HttpDelete("{productId:guidid}")]
        public async Task<IActionResult> DeleteProductAsync(string productId)
        {
            var success = await _productService.DeleteProductAsync(productId);
            return success ? Ok() : (IActionResult)BadRequest();
        }
    }
}