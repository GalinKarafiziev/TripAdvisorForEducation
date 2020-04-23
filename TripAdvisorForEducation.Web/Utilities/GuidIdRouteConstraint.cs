using Microsoft.AspNetCore.Routing.Constraints;

namespace TripAdvisorForEducation.Web.Utilities
{
    public class GuidIdRouteConstraint : RegexRouteConstraint
    {
        public GuidIdRouteConstraint() : base(@"[A-Z0-9]{8}-([A-Z0-9]{4}-){3}[A-Z0-9]{12}")
        {
        }
    }
}
