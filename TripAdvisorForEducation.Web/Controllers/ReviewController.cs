using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripAdvisorForEducation.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripAdvisorForEducation.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        
        public ReviewController(IReviewService reviewService) { this._reviewService = reviewService; }

        [HttpPost("reviews")]
        public IActionResult AddReview(int rating, string body, string academicsID, string productID) => Json(_reviewService.AddReview(rating, body, academicsID, productID));

        [HttpDelete("reviews")]
        public IActionResult DeleteReview(string id, string academicsID, string productID) => Json(_reviewService.DeleteReview(id, academicsID, productID));

        [HttpPost("reviews/update")]
        public IActionResult UpdateReview(string id, int rating, string body) => Json(_reviewService.UpdateReview(id, rating, body));
    }
}
