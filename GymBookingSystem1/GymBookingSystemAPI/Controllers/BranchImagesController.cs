using GymBookingSystemAPI.Data;
using GymBookingSystemAPI.Models;
using GymBookingSystemAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GymBookingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchImagesController : ControllerBase
    {
        private readonly GymBookingContext _context;

        public BranchImagesController(GymBookingContext context)
        {
            _context = context;
        }

        // POST: api/BranchImages
        [HttpPost]
        public async Task<ActionResult> AddBranchImage(AddBranchImageDTO dto)
        {
            var branch = await _context.GymBranches.FindAsync(dto.BranchID);
            if (branch == null)
            {
                return BadRequest(new { message = "Chi nhánh không tồn tại." });
            }

            var image = new BranchImage
            {
                BranchID = dto.BranchID,
                ImageURL = dto.ImageURL,
                Caption = dto.Caption,
                IsMainImage = dto.IsMainImage,
                DisplayOrder = dto.DisplayOrder,
                IsActive = true
            };

            try
            {
                _context.BranchImages.Add(image);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetBranchImage), new { id = image.ImageID }, new { message = "Thêm hình ảnh thành công!", imageID = image.ImageID });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Có lỗi xảy ra khi thêm hình ảnh: " + ex.Message });
            }
        }

        // GET: api/BranchImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchImageDTO>> GetBranchImage(int id)
        {
            var image = await _context.BranchImages
                .Where(i => i.ImageID == id && i.IsActive)
                .Select(i => new BranchImageDTO
                {
                    ImageID = i.ImageID,
                    ImageURL = i.ImageURL,
                    Caption = i.Caption,
                    IsMainImage = i.IsMainImage
                })
                .FirstOrDefaultAsync();

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        // GET: api/BranchImages/Branch/5
        [HttpGet("Branch/{branchId}")]
        public async Task<ActionResult<IEnumerable<BranchImageDTO>>> GetImagesByBranch(int branchId)
        {
            var images = await _context.BranchImages
                .Where(i => i.BranchID == branchId && i.IsActive)
                .Select(i => new BranchImageDTO
                {
                    ImageID = i.ImageID,
                    ImageURL = i.ImageURL,
                    Caption = i.Caption,
                    IsMainImage = i.IsMainImage
                })
                .ToListAsync();

            return images;
        }

        // PUT: api/BranchImages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranchImage(int id, UpdateBranchImageDTO dto)
        {
            var image = await _context.BranchImages.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            image.ImageURL = dto.ImageURL;
            image.Caption = dto.Caption;
            image.IsMainImage = dto.IsMainImage;
            image.DisplayOrder = dto.DisplayOrder;

            _context.Entry(image).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/BranchImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranchImage(int id)
        {
            var image = await _context.BranchImages.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            image.IsActive = false; // Xóa mềm
            _context.Entry(image).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}