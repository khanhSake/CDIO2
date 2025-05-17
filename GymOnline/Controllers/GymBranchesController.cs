using GymOnline.Data;
using GymOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GymOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymBranchesController : ControllerBase
    {
        private readonly GymContext _context;

        public GymBranchesController(GymContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetBranchNameById(int id)
        {
            var branch = await _context.GymBranches
                .Where(b => b.IsActive == true && b.BranchId == id)
                .Select(b => b.BranchName)
                .FirstOrDefaultAsync();

            if (branch == null)
            {
                return NotFound("Không tìm thấy chi nhánh với ID này.");
            }

            return Ok(branch);
        }

    }
}