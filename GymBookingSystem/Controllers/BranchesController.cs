using GymBookingSystem.Data;
using GymBookingSystem.Dtos;
using GymBookingSystem.Models; // Assuming models are in this namespace after scaffolding
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO; // Add this for Path operations

namespace GymBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly GymBookingSystemContext _context;

        public BranchesController(GymBookingSystemContext context)
        {
            _context = context;
        }

        // GET: api/branches/search
        [HttpGet("search")]
        public async Task<ActionResult<SearchResponseDto>> SearchBranches([FromQuery] string? city, [FromQuery] string? district)
        {
            // Start with the base query including related data
            var query = _context.GymBranches
                                .Include(b => b.Facilities)
                                .Include(b => b.MembershipPackages)
                                .Include(b => b.BranchImages)
                                .Where(b => b.IsActive == true) // Only search active branches
                                .AsQueryable(); // Use AsQueryable for building the query

            // Apply filters - Case-insensitive comparison
            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(b => EF.Functions.Like(b.City, $"%{city}%"));
            }

            if (!string.IsNullOrWhiteSpace(district))
            {
                query = query.Where(b => EF.Functions.Like(b.District, $"%{district}%"));
            }

            // Project the results into the DTO
            var branchResults = await query.Select(b => new BranchResultDto
            {
                BranchId = b.BranchId,
                Name = b.BranchName,
                Address = b.Address,
                Rating = b.RatingAverage,
                Latitude = b.Latitude,
                Longitude = b.Longitude,
                // Select the main image filename, fallback to the first, or null
                Image = b.BranchImages
                         .Where(img => img.IsActive == true) // Only active images
                         .OrderByDescending(img => img.IsMainImage) // Prioritize main image
                         .Select(img => Path.GetFileName(img.ImageUrl)) // Get only the filename
                         .FirstOrDefault(),
                // Select active facilities names
                Facilities = b.Facilities
                              .Where(f => f.IsActive == true)
                              .Select(f => f.FacilityName)
                              .ToList(),
                // Select active packages
                Packages = b.MembershipPackages
                            .Where(p => p.IsActive == true)
                            .Select(p => new PackageDto
                            {
                                Name = p.PackageName,
                                Price = p.Price,
                                DiscountedPrice = p.DiscountedPrice
                            }).ToList()
            }).ToListAsync();

            var response = new SearchResponseDto
            {
                Results = branchResults,
                TotalResults = branchResults.Count // Total count based on filtered results
            };

            return Ok(response);
        }
    }
} 