using AutoMapper;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.ViewModels;

namespace TripAdvisorForEducation.Web.Infrastructure
{
    public class AcademicUserProfile : Profile
    {
        // TODO: Create custom mappings (e.g. UserName = Input.Email)

        public AcademicUserProfile() => CreateMap<AcademicsUser, AcademicUserViewModel>().ReverseMap();
    }
}
