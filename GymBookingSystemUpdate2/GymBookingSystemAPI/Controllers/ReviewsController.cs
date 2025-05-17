using GymBookingSystemAPI.Data;
using GymBookingSystemAPI.DTOs;
using GymBookingSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GymBookingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly GymBookingContext _context;

        public ReviewsController(GymBookingContext context)
        {
            _context = context;
        }

        // GET: api/Reviews/Branch/5
        [HttpGet("Branch/{branchId}")]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReviewsByBranch(int branchId)
        {
            var reviews = await _context.Reviews
                .Include(r => r.User)
                .Where(r => r.BranchID == branchId && r.IsActive)
                .Select(r => new ReviewDTO
                {
                    ReviewID = r.ReviewID,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    UserFullName = r.User.FullName,
                    ReviewDate = r.ReviewDate
                })
                .ToListAsync();

            return reviews;
        }

        // PUT: api/Reviews/5/Approve
        [HttpPut("{id}/Approve")]
        public async Task<IActionResult> ApproveReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            review.IsApproved = true;
            await _context.SaveChangesAsync();

            var branch = await _context.GymBranches
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(b => b.BranchID == review.BranchID);
            if (branch != null)
            {
                var approvedReviews = branch.Reviews.Where(r => r.IsApproved && r.IsActive).ToList();
                branch.ReviewCount = approvedReviews.Count;
                branch.RatingAverage = approvedReviews.Any() ? (decimal)approvedReviews.Average(r => r.Rating) : 0;
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            var branch = await _context.GymBranches
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(b => b.BranchID == review.BranchID);
            if (branch != null)
            {
                var approvedReviews = branch.Reviews.Where(r => r.IsApproved && r.IsActive).ToList();
                branch.ReviewCount = approvedReviews.Count;
                branch.RatingAverage = approvedReviews.Any() ? (decimal)approvedReviews.Average(r => r.Rating) : 0;
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}