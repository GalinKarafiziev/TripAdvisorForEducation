using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TripAdvisorForEducation.Services;

namespace TripAdvisorForEducation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) => 
            _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync() =>
           Json((await _categoryService.GetCategoriesAsync()).ToList());

        [HttpGet("products/{categoryId:guidid}")]
        public async Task<IActionResult> GetCategoryProductsAsync([FromRoute]string categoryId) => 
            Json((await _categoryService.GetCategoryProductsAsync(categoryId)).ToList());
    }
}