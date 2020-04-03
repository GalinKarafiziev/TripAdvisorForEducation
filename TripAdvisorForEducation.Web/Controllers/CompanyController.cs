using Microsoft.AspNetCore.Mvc;
using TripAdvisorForEducation.Services.Contracts;

namespace TripAdvisorForEducation.Web.Controllers
{
    [Route("company")]
    public class CompanyController : Controller
    {
        private readonly ICompanyUserService companyUserService;

        public CompanyController(ICompanyUserService companyUserService) 
        {
            this.companyUserService = companyUserService;
        }

        [HttpGet("{companyId}")]
        public JsonResult GetCompany([FromRoute]string companyId) => companyUserService.GetCompany(companyId).ToJsonResult();

        [HttpGet("products/{companyId}")]
        public JsonResult GetCompanyProducts([FromRoute]string companyId) => 
            companyUserService.GetCompanyProducts(companyId).ToJsonResult();
    }
}