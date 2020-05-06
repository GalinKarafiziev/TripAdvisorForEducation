using AutoMapper;
using CuttingEdge.Conditions;
using System;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;
using TripAdvisorForEducation.Data.ViewModels;

namespace TripAdvisorForEducation.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
            
        public async Task<(bool success, string reviewId)> AddReviewAsync(ReviewViewModel reviewViewModel)
        {
            try
            {
                Condition.Requires(reviewViewModel.Body, nameof(reviewViewModel.Body)).IsNotNullOrEmpty();
                Condition.Requires(reviewViewModel.Rating, nameof(reviewViewModel.Rating)).IsGreaterOrEqual(0);
                Condition.Requires(reviewViewModel.UserId, nameof(reviewViewModel.UserId)).IsNotNullOrEmpty();
                Condition.Requires(reviewViewModel.ProductId, nameof(reviewViewModel.ProductId)).IsNotNullOrEmpty();

                var review = _mapper.Map<Review>(reviewViewModel);
                await _reviewRepository.AddAsync(review);
                await _reviewRepository.SaveChangesAsync();

                return (true, review.Id);
            }
            catch(Exception ex)
            {
                return (false, null);
            }
        }

        public async Task<Review> GetReview(string reviewID)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewID);
            
            return review;
        }

        public async Task<(bool success, string reviewId)> UpdateReviewAsync(string reviewID, ReviewViewModel reviewViewModel)
        {
            try
            {
                var review = await _reviewRepository.GetByIdAsync(reviewID);
                _mapper.Map(reviewViewModel, review);
                await _reviewRepository.SaveChangesAsync();
                
                return (true, reviewID);
            }
            catch(Exception ex)
            {
                return (false, null);
            }
        }

        public async Task<bool> DeleteReviewAsync(string reviewID)
        {
            try
            {
                var review = await _reviewRepository.GetByIdAsync(reviewID);
                await _reviewRepository.DeleteAsync(review);
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<AcademicsUser> GetAcademicsUserReviewAsync(string reviewId)
        {
           return await _reviewRepository.GetReviewUserAsync(reviewId);
        }
    }
}
