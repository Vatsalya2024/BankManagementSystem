using BOOKSTORE.Data;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Repository
{
    public class ReviewRepository : IRepository<int, Review>
    {
        private readonly BookStoreDBContext _bookStoreDBContext;

        public ReviewRepository(BookStoreDBContext bookStoreDBContext)
        {
            _bookStoreDBContext = bookStoreDBContext;
        }
        public async Task<Review> Add(Review item)
        {
            _bookStoreDBContext.Reviews.Add(item);
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
        }

        public async Task<Review?> Delete(int key)
        {
            var review = await Get(key);
            if (review== null)
            {
                throw new Exception();
            }
            else
            {
                _bookStoreDBContext.Reviews.Remove(review);
                await _bookStoreDBContext.SaveChangesAsync();
                return review;
            }

            throw new NotImplementedException();
        }

        public async Task<Review?> Get(int key)
        {
            var getorders = await GetAll();
            var getorder = getorders?.FirstOrDefault(g => g.ReviewId == key);
            if (getorder != null)
            {
                return getorder;
            }
            throw new NotImplementedException();
        }

        public Task<List<Review>?> GetAll()
        {
            var getorders = _bookStoreDBContext.Reviews.Include(a => a.ReviewId).ToListAsync();
            if (getorders == null)
            {
                return null;


            }
            return getorders;
        }

        public async Task<Review> Update(Review item)
        {
            _bookStoreDBContext.Entry<Review>(item).State = EntityState.Modified;
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
        }
    }
}
