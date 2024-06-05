using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOOKSTORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<ActionResult<Review>> AddReview([FromBody] Review review)
        {
            try
            {
                var addedReview = await _reviewService.AddReview(review); 
                return addedReview;
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Review>> UpdateReview(int id, [FromBody] Review review)
        {
            if (id != review.ReviewId)
            {
                return BadRequest("review ID mismatch");
            }

            try
            {
                var updatedReview = await _reviewService.UpdateReview(review);
                return Ok(updatedReview);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Review>> DeleteReview(int id)
        {
            try
            {
                var deletedReview = await _reviewService.DeleteReview(id);
                return Ok(deletedReview);
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
