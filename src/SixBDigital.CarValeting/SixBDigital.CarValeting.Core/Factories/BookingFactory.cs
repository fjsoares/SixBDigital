using SixBDigital.CarValeting.Core.DTOs;
using SixBDigital.CarValeting.Core.Entities;

namespace SixBDigital.CarValeting.Core.Factories
{
    public class BookingFactory
    {
        public Booking CreateBooking(CreateBookingDTO booking)
        {
            return new Booking
            {
                Name = booking.Name,
                BookingDateTime = booking.BookingDateTime,
                Flexibility = booking.Flexibility,
                VehicleSize = booking.VehicleSize,
                ContactNumber = booking.ContactNumber,
                EmailAddress = booking.EmailAddress,
                Approved = false
            };
        }
    }
}
