using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripAdvisorForEducation.Data.ViewModels;
using TripAdvisorForEducation.Services;

namespace TripAdvisorForEducation.Web.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts() => Json(_productService.GetProducts());

        [HttpGet("{productId}")]
        public IActionResult GetProduct([FromRoute]string productId) => Json(_productService.GetProduct(productId));

        [HttpGet("reviews/{productId}")]
        public IActionResult GetProductReviews([FromRoute]string productId) => Json(_productService.GetProductReviews(productId));

        [HttpGet("company/{productId}")]
        public IActionResult GetProductCompany([FromRoute]string productId) => Json(_productService.GetProductCompany(productId));

        [HttpGet("categories/{productId}")]
        public IActionResult GetProductCategories([FromRoute]string productId) => Json(_productService.GetProductCategories(productId));

        [HttpPost("new")]
        public IActionResult AddProduct([FromBody]ProductViewModel productViewModel)
        {
            var (success, productId) = _productService.AddProduct(productViewModel);
            return success ? Ok(new { productID = productId }) : (IActionResult)BadRequest();
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(string productId)
        {
            var success = _productService.DeleteProduct(productId);
            return success ? Ok() : (IActionResult)BadRequest();
        }
    }
}