using System;
using System.ComponentModel.DataAnnotations;

namespace SixBDigital.CarValeting.Web.ViewModel
{
    public class CreateBookingViewModel
    {
        [Required(ErrorMessage = "Please enter your name"), Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a booking date"), Display(Name = "Booking Date Time")]
        public DateTime BookingDateTime { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please set your flexibility"), Display(Name = "Flexibility")]
        public Flexibility Flexibility { get; set; }

        [Required(ErrorMessage = "Please set your vehicle size"), Display(Name = "Vehicle Size")]
        public VehicleSize VehicleSize { get; set; }

        [Required(ErrorMessage = "Please enter your contact number"), Phone, Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter your email address"),
         EmailAddress(ErrorMessage = "Please enter a valid email address"),
         Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}
