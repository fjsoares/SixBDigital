using System;
using SixBDigital.CarValeting.Core.Enumerators;

namespace SixBDigital.CarValeting.Core.Entities
{
    public class Booking : BaseEntity<Booking>
    {
        public string Name { get; set; }
        public DateTime BookingDateTime { get; internal set; }
        public Flexibility Flexibility { get; internal set; }
        public VehicleSize VehicleSize { get; internal set; }
        public string ContactNumber { get; internal set; }
        public string EmailAddress { get; internal set; }
        public bool Approved { get; internal set; }
        public int NumberOfToggleApproval { get; internal set; }
    }
}
