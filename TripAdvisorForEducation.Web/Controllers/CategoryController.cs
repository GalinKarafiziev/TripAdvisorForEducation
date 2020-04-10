using Microsoft.AspNetCore.Mvc;
using TripAdvisorForEducation.Services;

namespace TripAdvisorForEducation.Web.Controllers
{
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories() => Json(_categoryService.GetCategories());

        [HttpGet("products/{categoryId}")]
        public IActionResult GetCategoryProducts([FromRoute]string categoryId) => Json(_categoryService.GetCategoryProducts(categoryId));
    }
}