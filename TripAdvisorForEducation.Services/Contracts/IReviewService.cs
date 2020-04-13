using System;
using System.Collections.Generic;
using System.Text;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Services
{
    public interface IReviewService
    {
        Review AddReview(int rating, string body, string academicID, string productID);

        bool DeleteReview(string id, string academicID, string productID);

        Review UpdateReview(string id, int rating, string body);
    }
}
