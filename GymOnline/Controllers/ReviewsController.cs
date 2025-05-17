using GymOnline.Data;
using GymOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly GymContext _context;

        public ReviewsController(GymContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            review.ReviewDate = DateTime.Now;
            review.IsApproved = false;
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return NotFound();
            return review;
        }
        [HttpGet("trainer/{trainerId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByTrainer(int trainerId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.TrainerId == trainerId && r.IsActive == true)
                .ToListAsync();

            if (reviews == null || reviews.Count == 0)
            {
                return NotFound();
            }

            return reviews;
        }

    }

}
