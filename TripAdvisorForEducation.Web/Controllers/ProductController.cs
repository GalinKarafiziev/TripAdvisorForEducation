using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult AddProduct([FromBody]ProductViewModel productViewModel) => 
            Json(_productService.AddProduct(productViewModel.Description,
                productViewModel.Website,
                productViewModel.Name,
                productViewModel.CategoryId,
                productViewModel.UserId
                ));
        
        [HttpPut("{productid}")]
        public IActionResult UpdateProduct([FromBody]ProductViewModel productViewModel) =>
            Json(_productService.UpdateProduct(productViewModel.Description,
                productViewModel.Website,
                productViewModel.Name,
                productViewModel.CategoryId,
                productViewModel.productID
                ));

        [HttpDelete("{productid}")]
        public IActionResult DeleteProduct(string productID) => Json(_productService.DeleteProduct(productID));
   

        public class ProductViewModel
        {
            public string productID { get; set; }

            public string Description { get; set; }

            public string Website { get; set; }

            public string Name { get; set; }

            public string CategoryId { get; set; }

            public string UserId { get; set; }
        }
    }
}