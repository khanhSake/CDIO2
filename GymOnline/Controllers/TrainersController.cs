using GymOnline.Data;
using GymOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GymOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly GymContext _context;

        public TrainersController(GymContext context)
        {
            _context = context;
        }

        // GET: api/Trainers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainers(string? specialization = null)
        {
            // Sửa lỗi bằng cách so sánh với true để tránh lỗi với kiểu nullable bool
            var query = _context.Trainers.Where(t => t.IsActive == true && t.IsAvailable == true);

            if (!string.IsNullOrEmpty(specialization))
                query = query.Where(t => t.Specialization.Contains(specialization));

            return await query.ToListAsync();
        }

        // GET: api/Trainers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetTrainer(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null) return NotFound();
            return trainer;
        }
    }
}
