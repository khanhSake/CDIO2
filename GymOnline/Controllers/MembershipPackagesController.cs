using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymOnline.Data;
using GymOnline.Models;

[ApiController]
[Route("api/[controller]")]
public class MembershipPackagesController : ControllerBase
{
    private readonly GymContext _context;

    public MembershipPackagesController(GymContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetPackages()
    {
        var packages = await _context.MembershipPackages
            .Where(p => p.IsActive == true)
            .ToListAsync();
        return Ok(packages);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPackage(int id)
    {
        var package = await _context.MembershipPackages
            .Where(p => p.PackageId == id && p.IsActive == true)
            .FirstOrDefaultAsync();

        if (package == null)
        {
            return NotFound(new { error = "Membership package not found or inactive." });
        }

        return Ok(package);
    }
}