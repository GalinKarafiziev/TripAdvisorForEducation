using Microsoft.AspNetCore.Mvc;
using TripAdvisorForEducation.Services;

namespace TripAdvisorForEducation.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public JsonResult GetCategories() => categoryService.GetCategories().ToJsonResult();

        [HttpGet]
        public JsonResult GetCategoryProducts(string categoryId) 
            => categoryService.GetCategoryProducts(categoryId).ToJsonResult();
    }
}