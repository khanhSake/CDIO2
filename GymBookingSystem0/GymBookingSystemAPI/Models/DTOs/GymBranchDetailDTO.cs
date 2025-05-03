// Models/DTOs/GymBranchDetailDTO.cs
using System.Collections.Generic;

namespace GymBookingSystemAPI.Models.DTOs
{
    public class GymBranchDetailDTO
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OpeningHours { get; set; }
        public string Description { get; set; }
        public string MapLocation { get; set; }
        public decimal Latitude { get; set; } // Thay đổi từ double sang decimal
        public decimal Longitude { get; set; } // Thay đổi từ double sang decimal
        public decimal RatingAverage { get; set; } // Thay đổi từ double sang decimal
        public int ReviewCount { get; set; }
        public List<FacilityDTO> Facilities { get; set; }
        public List<BranchImageDTO> BranchImages { get; set; }
        public List<MembershipPackageDTO> MembershipPackages { get; set; }
        public List<ReviewDTO> Reviews { get; set; }
        public bool Featured { get; internal set; }
        public bool IsActive { get; internal set; }
    }
}