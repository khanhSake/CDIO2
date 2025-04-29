using System;

namespace GymBookingSystem.Dtos
{
    public class PackageDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
    }
} 