using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TripAdvisorForEducation.Web.Controllers
{
	[ApiController]
	[Route("_configuration")]
	public class OidcConfigurationController : Controller
	{
		public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider) => 
			ClientRequestParametersProvider = clientRequestParametersProvider;

		public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

		[HttpGet("{clientId}")]
		public async Task<IActionResult> GetClientRequestParametersAsync([FromRoute]string clientId) => 
			Ok(await Task.Run(() => ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId)));
	}
}
