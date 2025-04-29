using System.Collections.Generic;

namespace GymBookingSystem.Dtos
{
    public class BranchResultDto
    {
        public int BranchId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal? Rating { get; set; }
        public string? Image { get; set; }
        public List<PackageDto> Packages { get; set; } = new List<PackageDto>();
        public List<string> Facilities { get; set; } = new List<string>();
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
} 