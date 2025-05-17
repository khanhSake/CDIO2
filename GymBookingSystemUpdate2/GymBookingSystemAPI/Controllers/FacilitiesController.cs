using GymBookingSystemAPI.Data;
using GymBookingSystemAPI.DTOs;
using GymBookingSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GymBookingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private readonly GymBookingContext _context;

        public FacilitiesController(GymBookingContext context)
        {
            _context = context;
        }

        // GET: api/Facilities/Branch/5
        [HttpGet("Branch/{branchId}")]
        public async Task<ActionResult<IEnumerable<FacilityDTO>>> GetFacilitiesByBranch(int branchId)
        {
            var facilities = await _context.Facilities
                .Where(f => f.BranchID == branchId && f.IsActive)
                .Select(f => new FacilityDTO
                {
                    FacilityID = f.FacilityID,
                    FacilityName = f.FacilityName,
                    Description = f.Description,
                    IconClass = f.IconClass
                })
                .ToListAsync();

            return facilities;
        }

        // POST: api/Facilities
        [HttpPost]
        public async Task<ActionResult<Facility>> AddFacility(AddFacilityDTO dto)
        {
            var branch = await _context.GymBranches.FindAsync(dto.BranchID);
            if (branch == null)
            {
                return BadRequest(new { message = "Chi nhánh không tồn tại." });
            }

            var facility = new Facility
            {
                BranchID = dto.BranchID,
                FacilityName = dto.FacilityName,
                Description = dto.Description,
                IconClass = dto.IconClass,
                IsActive = true
            };

            try
            {
                _context.Facilities.Add(facility);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetFacility), new { id = facility.FacilityID }, new { message = "Thêm tiện ích thành công!", facilityID = facility.FacilityID });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Có lỗi xảy ra khi thêm tiện ích: " + ex.Message });
            }
        }

        // GET: api/Facilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacilityDTO>> GetFacility(int id)
        {
            var facility = await _context.Facilities
                .Where(f => f.FacilityID == id && f.IsActive)
                .Select(f => new FacilityDTO
                {
                    FacilityID = f.FacilityID,
                    FacilityName = f.FacilityName,
                    Description = f.Description,
                    IconClass = f.IconClass
                })
                .FirstOrDefaultAsync();

            if (facility == null)
            {
                return NotFound();
            }

            return facility;
        }

        // PUT: api/Facilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFacility(int id, UpdateFacilityDTO dto)
        {
            var facility = await _context.Facilities.FindAsync(id);
            if (facility == null)
            {
                return NotFound(new { message = "Tiện ích không tồn tại." });
            }

            facility.FacilityName = dto.FacilityName;
            facility.Description = dto.Description;
            facility.IconClass = dto.IconClass;

            try
            {
                _context.Entry(facility).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Cập nhật tiện ích thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Có lỗi xảy ra khi cập nhật tiện ích: " + ex.Message });
            }
        }

        // DELETE: api/Facilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacility(int id)
        {
            var facility = await _context.Facilities.FindAsync(id);
            if (facility == null)
            {
                return NotFound(new { message = "Tiện ích không tồn tại." });
            }

            try
            {
                _context.Facilities.Remove(facility); // Perform hard delete
                await _context.SaveChangesAsync();
                return Ok(new { message = "Xóa tiện ích thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Có lỗi xảy ra khi xóa tiện ích: " + ex.Message });
            }
        }
    }
}