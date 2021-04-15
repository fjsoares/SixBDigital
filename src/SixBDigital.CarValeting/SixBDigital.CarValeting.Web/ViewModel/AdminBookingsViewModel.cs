using System;
using System.Collections.Generic;

namespace SixBDigital.CarValeting.Web.ViewModel
{
    public class AdminBookingsViewModel
    {
        public List<BookingViewModel> BookingViewModel { get; set; } = new List<BookingViewModel>();
    }

    public class BookingViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public DateTime BookingDateTime { get; set; }
        public Flexibility Flexibility { get; set; }
        public VehicleSize VehicleSize { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool Approved { get; set; }
    }
}
