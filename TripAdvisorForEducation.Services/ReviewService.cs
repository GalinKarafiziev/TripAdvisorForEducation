using System;
using System.Collections.Generic;
using System.Text;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IAcademicsUserRepository _academicsUserRepository;
        private readonly IProductRepository _productRepository;

        public ReviewService(IReviewRepository reviewRepository, IAcademicsUserRepository academicsUserRepository, IProductRepository productRepository)
        {
            this._reviewRepository = reviewRepository;
            this._academicsUserRepository = academicsUserRepository;
            this._productRepository = productRepository;
        }

        public Review AddReview(int rating, string body, string academicsID, string productID)
        {
            AcademicsUser user = _academicsUserRepository.GetById(academicsID);
            Product product = _productRepository.GetById(productID);

            var review = new Review() { Rating = rating, Body = body, User = user, UserId = user.Id, Product = product, ProductId = product.ProductId, };

            user.Reviews.Add(review);
            product.Reviews.Add(review);
           
            _reviewRepository.Add(review);
            _reviewRepository.SaveChanges();
            
            return review;
        }

        public bool DeleteReview(string id, string academicsID, string productID)
        {
            Review review = _reviewRepository.GetById(id);
            AcademicsUser user = _academicsUserRepository.GetById(academicsID);
            Product product = _productRepository.GetById(productID);

            user.Reviews.Remove(review);
            product.Reviews.Remove(review);

            _reviewRepository.Delete(review);
            _reviewRepository.SaveChanges();

            if(_reviewRepository.GetById(id) == null && !(user.Reviews.Contains(review) && !(product.Reviews.Contains(review))))
                return true;
            return false;
        }

        public Review UpdateReview(string id, int rating, string body)
        {
            Review review = _reviewRepository.GetById(id);
            AcademicsUser user = _academicsUserRepository.GetById(review.UserId);
            Product product = _productRepository.GetById(review.ProductId);
            
            review.Body = body;
            review.Rating = rating;
            review.Product = product;
            review.UserId = user.Id;
            review.ProductId = product.ProductId;

            review.User = user;
            review.Product = product;

            _reviewRepository.Update(review);
            _reviewRepository.SaveChanges();

            if (user.Reviews.Contains(review) && product.Reviews.Contains(review))
                return review;
            
            return null;
            
            
        }


    }
}
