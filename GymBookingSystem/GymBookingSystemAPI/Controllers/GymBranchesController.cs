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
                RatingAverage = (decimal)branch.RatingAverage,
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
                RatingAverage = (decimal)branch.RatingAverage,
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
    }
}