using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.ViewModels;

namespace TripAdvisorForEducation.Services
{
    public interface IReviewService
    {
        Task<(bool success, string reviewId)> AddReviewAsync(ReviewViewModel reviewViewModel);

        Task<(bool success, string reviewId)> UpdateReviewAsync(string reviewID, ReviewViewModel reviewViewModel);

        Task<Review> GetReview(string reviewID);

        Task<AcademicsUser> GetAcademicsUserReviewAsync(string reviewId);

        Task<bool> DeleteReviewAsync(string reviewId);
    }
}
