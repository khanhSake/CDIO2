using GymBookingSystemAPI.Data;
using GymBookingSystemAPI.Models;
using GymBookingSystemAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GymBookingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymBranchesController : ControllerBase
    {
        private readonly GymBookingContext _context;

        public GymBranchesController(GymBookingContext context)
        {
            _context = context;
        }

        // GET: api/GymBranches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymBranchDetailDTO>>> GetGymBranches()
        {
            var branches = await _context.GymBranches
                .Include(b => b.Facilities)
                .Include(b => b.BranchImages)
                .Include(b => b.MembershipPackages)
                .Include(b => b.Reviews)
                .ThenInclude(r => r.User)
                .Where(b => b.IsActive)
                .ToListAsync();

            var branchDetails = branches.Select(branch => new GymBranchDetailDTO
            {
                BranchID = branch.BranchID,
                BranchName = branch.BranchName,
                Address = branch.Address,
                City = branch.City,
                District = branch.District,
                PhoneNumber = branch.PhoneNumber,
                Email = branch.Email,
                OpeningHours = branch.OpeningHours,
                Description = branch.Description,
                MapLocation = branch.MapLocation,
                Latitude = branch.Latitude,
                Longitude = branch.Longitude,
                RatingAverage = branch.RatingAverage,
                ReviewCount = branch.ReviewCount,
                Facilities = branch.Facilities.Where(f => f.IsActive).Select(f => new FacilityDTO
                {
                    FacilityID = f.FacilityID,
                    FacilityName = f.FacilityName,
                    Description = f.Description,
                    IconClass = f.IconClass
                }).ToList(),
                BranchImages = branch.BranchImages.Where(i => i.IsActive).Select(i => new BranchImageDTO
                {
                    ImageID = i.ImageID,
                    ImageURL = i.ImageURL,
                    Caption = i.Caption,
                    IsMainImage = i.IsMainImage
                }).ToList(),
                MembershipPackages = branch.MembershipPackages.Where(p => p.IsActive).Select(p => new MembershipPackageDTO
                {
                    PackageID = p.PackageID,
                    PackageName = p.PackageName,
                    Duration = p.Duration,
                    DurationType = p.DurationType,
                    Price = p.Price,
                    DiscountedPrice = p.DiscountedPrice,
                    Description = p.Description,
                    Features = p.Features,
                    IsPopular = p.IsPopular
                }).ToList(),
                Reviews = branch.Reviews.Where(r => r.IsActive && r.IsApproved).Select(r => new ReviewDTO
                {
                    ReviewID = r.ReviewID,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    UserFullName = r.User.FullName,
                    ReviewDate = r.ReviewDate
                }).ToList()
            }).ToList();

            return branchDetails;
        }

        // GET: api/GymBranches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GymBranchDetailDTO>> GetGymBranchDetail(int id)
        {
            var branch = await _context.GymBranches
                .Include(b => b.Facilities)
                .Include(b => b.BranchImages)
                .Include(b => b.MembershipPackages)
                .Include(b => b.Reviews)
                .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(b => b.BranchID == id && b.IsActive);

            if (branch == null)
            {
                return NotFound();
            }

            var branchDetail = new GymBranchDetailDTO
            {
                BranchID = branch.BranchID,
                BranchName = branch.BranchName,
                Address = branch.Address,
                City = branch.City,
                District = branch.District,
                PhoneNumber = branch.PhoneNumber,
                Email = branch.Email,
                OpeningHours = branch.OpeningHours,
                Description = branch.Description,
                MapLocation = branch.MapLocation,
                Latitude = branch.Latitude,
                Longitude = branch.Longitude,
                RatingAverage = branch.RatingAverage,
                ReviewCount = branch.ReviewCount,
                Facilities = branch.Facilities.Where(f => f.IsActive).Select(f => new FacilityDTO
                {
                    FacilityID = f.FacilityID,
                    FacilityName = f.FacilityName,
                    Description = f.Description,
                    IconClass = f.IconClass
                }).ToList(),
                BranchImages = branch.BranchImages.Where(i => i.IsActive).Select(i => new BranchImageDTO
                {
                    ImageID = i.ImageID,
                    ImageURL = i.ImageURL,
                    Caption = i.Caption,
                    IsMainImage = i.IsMainImage
                }).ToList(),
                MembershipPackages = branch.MembershipPackages.Where(p => p.IsActive).Select(p => new MembershipPackageDTO
                {
                    PackageID = p.PackageID,
                    PackageName = p.PackageName,
                    Duration = p.Duration,
                    DurationType = p.DurationType,
                    Price = p.Price,
                    DiscountedPrice = p.DiscountedPrice,
                    Description = p.Description,
                    Features = p.Features,
                    IsPopular = p.IsPopular
                }).ToList(),
                Reviews = branch.Reviews.Where(r => r.IsActive && r.IsApproved).Select(r => new ReviewDTO
                {
                    ReviewID = r.ReviewID,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    UserFullName = r.User.FullName,
                    ReviewDate = r.ReviewDate
                }).ToList()
            };

            return branchDetail;
        }

        // POST: api/GymBranches
        [HttpPost]
        public async Task<ActionResult<GymBranch>> AddGymBranch(AddGymBranchDTO dto)
        {
            if (await _context.GymBranches.AnyAsync(b => b.BranchID == dto.BranchID))
            {
                return BadRequest(new { message = "BranchID đã tồn tại. Vui lòng chọn BranchID khác." });
            }

            var provider = await _context.GymProviders.FindAsync(dto.ProviderID);
            if (provider == null)
            {
                return BadRequest(new { message = "Nhà cung cấp không tồn tại." });
            }

            var branch = new GymBranch
            {
                BranchID = dto.BranchID,
                ProviderID = dto.ProviderID,
                BranchName = dto.BranchName,
                Address = dto.Address,
                City = dto.City,
                District = dto.District,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                OpeningHours = dto.OpeningHours,
                Description = dto.Description,
                MapLocation = dto.MapLocation,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                RatingAverage = 0,
                ReviewCount = 0,
                Featured = false,
                IsActive = true
            };

            try
            {
                _context.GymBranches.Add(branch);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetGymBranchDetail), new { id = branch.BranchID }, new { message = "Thêm chi nhánh thành công!", branchID = branch.BranchID });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Có lỗi xảy ra khi thêm chi nhánh: " + ex.Message });
            }
        }

        // PUT: api/GymBranches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGymBranch(int id, UpdateGymBranchDTO dto)
        {
            var branch = await _context.GymBranches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            branch.BranchName = dto.BranchName;
            branch.Address = dto.Address;
            branch.City = dto.City;
            branch.District = dto.District;
            branch.PhoneNumber = dto.PhoneNumber;
            branch.Email = dto.Email;
            branch.OpeningHours = dto.OpeningHours;
            branch.Description = dto.Description;
            branch.MapLocation = dto.MapLocation;
            branch.Latitude = dto.Latitude;
            branch.Longitude = dto.Longitude;

            _context.Entry(branch).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/GymBranches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymBranch(int id)
        {
            var branch = await _context.GymBranches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            // Xóa các bản ghi liên quan trước
            _context.Facilities.RemoveRange(_context.Facilities.Where(f => f.BranchID == id));
            _context.BranchImages.RemoveRange(_context.BranchImages.Where(i => i.BranchID == id));
            _context.MembershipPackages.RemoveRange(_context.MembershipPackages.Where(p => p.BranchID == id));

            // Xóa chi nhánh
            _context.GymBranches.Remove(branch);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}