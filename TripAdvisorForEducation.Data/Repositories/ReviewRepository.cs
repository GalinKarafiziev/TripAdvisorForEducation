using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Base;
using TripAdvisorForEducation.Data.Repositories.Contracts;
using TripAdvisorForEducation.Data.Repositories.Extensions;

namespace TripAdvisorForEducation.Data.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(TripAdvisorForEducationDbContext context) 
            : base(context)
        {
        }

        public async Task<AcademicsUser> GetReviewUserAsync(string reviewId)
        {
            var review = await GetByIdAsync(reviewId);
            await review.LoadEntityReferenceAsync(Context, x => x.User);

            return review.User;
        }
    }
}
