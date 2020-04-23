using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TripAdvisorForEducation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        public SearchController()
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}