using System;
using SixBDigital.CarValeting.Core.Enumerators;

namespace SixBDigital.CarValeting.Core.DTOs
{
    public class CreateBookingDTO
    {
        public string Name { get; set; }
        public DateTime BookingDateTime { get; set; }
        public Flexibility Flexibility { get; set; }
        public VehicleSize VehicleSize { get; set; }
        public string ContactNumber { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
	}
}
