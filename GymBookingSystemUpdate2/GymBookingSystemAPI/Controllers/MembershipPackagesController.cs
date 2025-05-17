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
    public class MembershipPackagesController : ControllerBase
    {
        private readonly GymBookingContext _context;

        public MembershipPackagesController(GymBookingContext context)
        {
            _context = context;
        }

        // GET: api/MembershipPackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MembershipPackageDTO>> GetMembershipPackage(int id)
        {
            var package = await _context.MembershipPackages
                .Where(p => p.PackageID == id && p.IsActive)
                .Select(p => new MembershipPackageDTO
                {
                    PackageID = p.PackageID,
                    PackageName = p.PackageName,
                    Duration = p.Duration,
                    DurationType = p.DurationType,
                    Price = p.Price,
                    DiscountedPrice = p.DiscountedPrice,
                    Description = p.Description,
                    Features = p.Features,
                    IsPopular = p.IsPopular,
                    BranchID = p.BranchID
                })
                .FirstOrDefaultAsync();

            if (package == null)
            {
                return NotFound();
            }

            return package;
        }

        // POST: api/MembershipPackages
        [HttpPost]
        public async Task<ActionResult> AddMembershipPackage(AddMembershipPackageDTO dto)
        {
            // Validate BranchID exists and is active
            var branch = await _context.GymBranches
                .Where(b => b.BranchID == dto.BranchID && b.IsActive)
                .FirstOrDefaultAsync();
            if (branch == null)
            {
                return BadRequest(new { message = $"Chi nhánh có mã BranchID {dto.BranchID} không tồn tại hoặc không hoạt động." });
            }

            var package = new MembershipPackage
            {
                BranchID = dto.BranchID,
                PackageName = dto.PackageName,
                Duration = dto.Duration,
                DurationType = dto.DurationType,
                Price = dto.Price,
                DiscountedPrice = dto.DiscountedPrice,
                Description = dto.Description,
                Features = dto.Features,
                IsPopular = dto.IsPopular,
                IsActive = true
            };

            try
            {
                _context.MembershipPackages.Add(package);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetMembershipPackage), new { id = package.PackageID }, new { message = "Thêm gói tập thành công!", packageID = package.PackageID });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Có lỗi xảy ra khi thêm gói tập: " + ex.Message });
            }
        }

        // PUT: api/MembershipPackages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMembershipPackage(int id, UpdateMembershipPackageDTO dto)
        {
            var package = await _context.MembershipPackages
                .Where(p => p.PackageID == id && p.IsActive)
                .FirstOrDefaultAsync();
            if (package == null)
            {
                return NotFound(new { message = "Gói tập không tồn tại hoặc không hoạt động." });
            }

            // Optionally validate BranchID if it's being updated (though typically BranchID shouldn't change)
            var branch = await _context.GymBranches
                .Where(b => b.BranchID == package.BranchID && b.IsActive)
                .FirstOrDefaultAsync();
            if (branch == null)
            {
                return BadRequest(new { message = $"Chi nhánh có mã BranchID {package.BranchID} không tồn tại hoặc không hoạt động." });
            }

            package.PackageName = dto.PackageName;
            package.Duration = dto.Duration;
            package.DurationType = dto.DurationType;
            package.Price = dto.Price;
            package.DiscountedPrice = dto.DiscountedPrice;
            package.Description = dto.Description;
            package.Features = dto.Features;
            package.IsPopular = dto.IsPopular;

            try
            {
                _context.Entry(package).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Có lỗi xảy ra khi cập nhật gói tập: " + ex.Message });
            }
        }

        // DELETE: api/MembershipPackages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembershipPackage(int id)
        {
            var package = await _context.MembershipPackages.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            try
            {
                _context.MembershipPackages.Remove(package);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Có lỗi xảy ra khi xóa gói tập: " + ex.Message });
            }
        }
    }
}