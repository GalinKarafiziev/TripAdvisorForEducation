using AutoMapper;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.ViewModels;

namespace TripAdvisorForEducation.Web.Infrastructure
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap().ForAllMembers(opts => 
                opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
