using System;
using SixBDigital.CarValeting.Core.Enumerators;

namespace SixBDigital.CarValeting.Core.DTOs
{
    public class UpdateBookingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BookingDateTime { get; set; }
        public Flexibility Flexibility { get; set; }
        public VehicleSize VehicleSize { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool Approved { get; set; }
    }
}
