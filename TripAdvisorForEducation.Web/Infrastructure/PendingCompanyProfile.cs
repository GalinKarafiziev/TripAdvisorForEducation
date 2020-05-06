using AutoMapper;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.ViewModels;

namespace TripAdvisorForEducation.Web.Infrastructure
{
    public class PendingCompanyProfile : Profile
    {
        public PendingCompanyProfile() => CreateMap<PendingCompany, PendingCompanyViewModel>().ReverseMap();
    }
}
