using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TripAdvisorForEducation.Services;
using TripAdvisorForEducation.Services.Contracts;

namespace TripAdvisorForEducation.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IAcademicsUserService _academicsUserService;
        private readonly ICompanyUserService _companyUserService;

        public AdminController(IAcademicsUserService academicsUserService, ICompanyUserService companyUserService)
        {
            _academicsUserService = academicsUserService;
            _companyUserService = companyUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var academicsUsers = (await _academicsUserService.GetAcademicsUsersAsync()).Cast<IdentityUser>();
            var companyUsers = (await _companyUserService.GetCompanyUsersAsync()).Cast<IdentityUser>();

            return Json(academicsUsers.Concat(companyUsers));
        } 
    }
}