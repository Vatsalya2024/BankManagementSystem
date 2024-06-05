using BOOKSTORE.Models.Entities;

namespace BOOKSTORE.Interface
{
    public interface IReviewService
    {

        public Task<Review> AddReview(Review review);
        public Task<List<Review>> GetAllReview();
        public Task<Review> GetReviewById(int id);
        public Task<bool> DeleteReview(int id);
        public Task<Review> UpdateReview(Review review);
    }
}
