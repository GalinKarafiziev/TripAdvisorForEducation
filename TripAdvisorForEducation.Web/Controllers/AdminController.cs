using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.ViewModels;
using TripAdvisorForEducation.Services;
using TripAdvisorForEducation.Services.Contracts;
using TripAdvisorForEducation.Services.Messaging;

namespace TripAdvisorForEducation.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IAcademicsUserService _academicsUserService;
        private readonly ICompanyUserService _companyUserService;
        private readonly IPendingCompanyService _pendingCompanyService;
        private readonly IEmailSender _emailSenderService;

        public AdminController(IAcademicsUserService academicsUserService, ICompanyUserService companyUserService,
            IPendingCompanyService pendingCompanyService, IEmailSender emailSenderService)
        {
            _academicsUserService = academicsUserService;
            _companyUserService = companyUserService;
            _pendingCompanyService = pendingCompanyService;
            _emailSenderService = emailSenderService;
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

        [HttpGet("pending/{companyId:guidid}")]
        public async Task<IActionResult> GetPendingCompany([FromRoute]string companyId) =>
            Json(await _pendingCompanyService.GetPendingCompanyAsync(companyId));

        [HttpGet("pending/approve/{companyId:guid}")]
        public async Task<IActionResult> ApprovePendingCompany([FromRoute]string companyId)
        {
            var pendingCompany = await _pendingCompanyService.GetPendingCompanyAsync(companyId);

            var message = new Message(new string[] { $"{pendingCompany.Email}" }, "Join now", 
                $"https://localhost:44361/Identity/Account/Register?returnUrl=/authentication/login/&token={pendingCompany.Token}");
            await _emailSenderService.SendEmailAsync(message);

            return Ok();
        }

        [HttpPut("pending/deactivate/{companyId:guidid}")]
        public async Task<IActionResult> DeclinePendingCompany([FromRoute]string companyId)
        {
            var success = await _pendingCompanyService.DeclinePendingCompany(companyId);
            return success ? Ok() : (IActionResult)BadRequest();
        }
    }
}