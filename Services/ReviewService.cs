using BOOKSTORE.Exception;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using BOOKSTORE.Repository;

namespace BOOKSTORE.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<int, Review> _reviewRepository;
        private readonly ILogger<ReviewService> _logger;
        public ReviewService(IRepository<int, Review> reviewRepository, ILogger<ReviewService> logger)
        {
            _reviewRepository = reviewRepository;
            _logger = logger;
        }
        public async Task<Review> AddReview(Review review)
        {
            return await _reviewRepository.Add(review);
        }

        public async Task<bool> DeleteReview(int id)
        {
            var review = await _reviewRepository.Get(id);
            if (review != null)
            {
                await _reviewRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<List<Review>> GetAllReview()
        {
            return await _reviewRepository.GetAll();
        }

        public async Task<Review> GetReviewById(int id)
        {
            var reviews = await _reviewRepository.GetAll();
            var review = reviews.FirstOrDefault(e => e.ReviewId == id);
            if (review != null)

            {
                return review;
            }
            throw new NoReviewException();
        }

        public async Task<Review> UpdateReview(Review review)
        {
            var reviews = await _reviewRepository.Get(review.ReviewId);
            if (reviews != null)
            {
               reviews.Rating = review.Rating;
                reviews.Comment = review.Comment;
                reviews = await _reviewRepository.Update(reviews);
                return reviews;

            }
            throw new NoReviewException();
        }
    }
}
