using Microsoft.AspNetCore.Mvc;
using TripAdvisorForEducation.Services;

namespace TripAdvisorForEducation.Web.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("{productId}")]
        public JsonResult GetProduct([FromRoute]string productId) => productService.GetProduct(productId).ToJsonResult();

        [HttpGet]
        public JsonResult GetProducts() => productService.GetProducts().ToJsonResult();

        [HttpGet("reviews/{productId}")]
        public JsonResult GetProductReviews(string productId) => productService.GetProductReviews(productId).ToJsonResult();

        [HttpGet("company/{productId}")]
        public JsonResult GetProductCompany(string productId) => productService.GetProductCompany(productId).ToJsonResult();

        [HttpGet("categories/{productId}")]
        public JsonResult GetProductCategories(string productId) => productService.GetProductCategories(productId).ToJsonResult();
    }
}