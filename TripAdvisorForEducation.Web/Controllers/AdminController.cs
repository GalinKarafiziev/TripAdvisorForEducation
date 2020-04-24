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
        private readonly IPendingCompanyService _pendingCompanyService;

        public AdminController(IAcademicsUserService academicsUserService, ICompanyUserService companyUserService, 
            IPendingCompanyService pendingCompanyService)
        {
            _academicsUserService = academicsUserService;
            _companyUserService = companyUserService;
            _pendingCompanyService = pendingCompanyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var academicsUsers = (await _academicsUserService.GetAcademicsUsersAsync()).Cast<IdentityUser>();
            var companyUsers = (await _companyUserService.GetCompanyUsersAsync()).Cast<IdentityUser>();

            return Json(academicsUsers.Concat(companyUsers));
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingCompanies() =>
            Json(await _pendingCompanyService.GetPendingCompaniesAsync());
    }
}