using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data.Repositories.Contracts
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<AcademicsUser> GetReviewUserAsync(string reviewId);
    }
}
