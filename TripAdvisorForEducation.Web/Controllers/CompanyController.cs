using Microsoft.AspNetCore.Mvc;
using TripAdvisorForEducation.Services.Contracts;

namespace TripAdvisorForEducation.Web.Controllers
{
    [Route("company")]
    public class CompanyController : Controller
    {
        private readonly ICompanyUserService _companyUserService;

        public CompanyController(ICompanyUserService companyUserService) 
        {
            _companyUserService = companyUserService;
        }

        [HttpGet("{companyId}")]
        public IActionResult GetCompany([FromRoute]string companyId) => Json(_companyUserService.GetCompany(companyId));

        [HttpGet("products/{companyId}")]
        public IActionResult GetCompanyProducts([FromRoute]string companyId) => Json(_companyUserService.GetCompanyProducts(companyId));
    }
}