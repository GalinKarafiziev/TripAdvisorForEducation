using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.ViewModels;

namespace TripAdvisorForEducation.Web.Infrastructure
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {

            CreateMap<Review, ReviewViewModel>().ReverseMap().ForAllMembers((opts => opts.Condition((src, dest, srcMember) => srcMember != null))); ;
        }
    }
}
