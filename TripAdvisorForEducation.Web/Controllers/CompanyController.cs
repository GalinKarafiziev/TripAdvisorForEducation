using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TripAdvisorForEducation.Services.Contracts;

namespace TripAdvisorForEducation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyUserService _companyUserService;

        public CompanyController(ICompanyUserService companyUserService) => 
            _companyUserService = companyUserService;

        [HttpGet("{companyId:guidid}")]
        public async Task<IActionResult> GetCompanyAsync([FromRoute]string companyId) =>
            Json(await _companyUserService.GetCompanyAsync(companyId));

        [HttpGet("products/{companyId:guidid}")]
        public async Task<IActionResult> GetCompanyProductsAsync([FromRoute]string companyId) => 
            Json((await _companyUserService.GetCompanyProductsAsync(companyId)).ToList());
    }
}