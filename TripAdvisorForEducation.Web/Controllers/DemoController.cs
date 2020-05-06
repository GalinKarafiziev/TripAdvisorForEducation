using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.ViewModels;
using TripAdvisorForEducation.Services.Contracts;
using TripAdvisorForEducation.Services.Messaging;

namespace TripAdvisorForEducation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : Controller
    {
        private readonly IPendingCompanyService _pendingCompnayService;
        private readonly IEmailSender _emailSenderService;

        public DemoController(IPendingCompanyService pendingCompnayService, IEmailSender emailSender)
        {
            _pendingCompnayService = pendingCompnayService;
            _emailSenderService = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyRequest([FromBody]PendingCompanyViewModel pendingCompany) 
        {
            var success = await _pendingCompnayService.AddPendingCompanyAsync(pendingCompany);

            if (success)
            {
                var message = new Message(new string[] { "a.gencheva@student.fontys.nl" }, "Test subject", "https://localhost:44361/admin");
                await _emailSenderService.SendEmailAsync(message);
            }

            return success ? Ok() : (IActionResult)BadRequest();
        }
    }
}
