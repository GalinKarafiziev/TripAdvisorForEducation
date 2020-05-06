using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.ViewModels;
using TripAdvisorForEducation.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripAdvisorForEducation.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService) { this._reviewService = reviewService; }

        [HttpPost("new")]
        public async Task<IActionResult> AddReview([FromBody] ReviewViewModel reviewViewModel)
        {
            var (success, reviewId) = await _reviewService.AddReviewAsync(reviewViewModel);
            return success ? Ok(new { reviewID = reviewId }) : (IActionResult)BadRequest();
        }

        [HttpPut("{reviewId:guidid}")]
        public async Task<IActionResult> UpdateReview([FromBody] ReviewViewModel reviewViewModel, string reviewId)
        {
            var (success, reviewIds) = await _reviewService.UpdateReviewAsync(reviewId, reviewViewModel);
            return success ? Ok(new { reviewID = reviewIds }) : (IActionResult)BadRequest();
        }

        [HttpGet("{reviewId}/user")]
        public async Task<IActionResult> GetAcademicsReview(string reviewId) =>
            Json(await _reviewService.GetAcademicsUserReviewAsync(reviewId));

        [HttpDelete("{reviewId:guidid}")]
        public async Task<IActionResult> DeleteReview(string reviewId)
        {
            var success = await _reviewService.DeleteReviewAsync(reviewId);
            return success ? Ok(success) : (IActionResult)BadRequest();
        }

        [HttpGet("{reviewId:guidid}")]
        public async Task<IActionResult> GetReview(string reviewId) => Json(await _reviewService.GetReview(reviewId));
    }
}
