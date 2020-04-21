using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult GetUsers()
        {
            var academicsUsers = _academicsUserService.GetAcademicsUsers().Cast<IdentityUser>();
            var companyUsers = _companyUserService.GetCompanyUsers().Cast<IdentityUser>();

            var res = academicsUsers.Union(companyUsers);

            return Json(res);
        } 
    }
}