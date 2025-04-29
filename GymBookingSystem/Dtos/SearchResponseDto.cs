using System.Collections.Generic;

namespace GymBookingSystem.Dtos
{
    public class SearchResponseDto
    {
        public List<BranchResultDto> Results { get; set; } = new List<BranchResultDto>();
        public int TotalResults { get; set; }
    }
} 