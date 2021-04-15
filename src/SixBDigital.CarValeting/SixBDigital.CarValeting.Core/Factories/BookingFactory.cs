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

        public Booking CreateBooking(UpdateBookingDTO booking)
        {
            return new Booking
            {
                Id = booking.Id,
                Name = booking.Name,
                BookingDateTime = booking.BookingDateTime,
                Flexibility = booking.Flexibility,
                VehicleSize = booking.VehicleSize,
                ContactNumber = booking.ContactNumber,
                EmailAddress = booking.EmailAddress,
                Approved = false
            };
        }

        public BookingDTO CreateBookingDTO(Booking booking)
        {
            return new BookingDTO
            {
                Id = booking.Id,
                CreatedAt = booking.CreatedAt,
                UpdatedAt = booking.UpdatedAt,
                Name = booking.Name,
                BookingDateTime = booking.BookingDateTime,
                Flexibility = booking.Flexibility,
                VehicleSize = booking.VehicleSize,
                ContactNumber = booking.ContactNumber,
                EmailAddress = booking.EmailAddress,
                Approved = booking.Approved
            };
        }
    }
}
