using System.Collections.Generic;
using System.Linq;
using SixBDigital.CarValeting.Core.DTOs;
using SixBDigital.CarValeting.Web.ViewModel;
using Flexibility = SixBDigital.CarValeting.Core.Enumerators.Flexibility;
using VehicleSize = SixBDigital.CarValeting.Core.Enumerators.VehicleSize;

namespace SixBDigital.CarValeting.Web.Factories
{
    public class BookingFactory
    {
        public CreateBookingDTO CreateBookingDto(CreateBookingViewModel createBookingViewModel)
        {
            return new CreateBookingDTO
            {
                Name = createBookingViewModel.Name,
                BookingDateTime = createBookingViewModel.BookingDateTime,
                Flexibility = (Flexibility) createBookingViewModel.Flexibility,
                VehicleSize = (VehicleSize) createBookingViewModel.VehicleSize,
                ContactNumber = createBookingViewModel.ContactNumber,
                EmailAddress = createBookingViewModel.EmailAddress
            };
        }
        public UpdateBookingDTO CreateUpdateBookingDto(BookingViewModel bookingViewModel)
        {
            return new UpdateBookingDTO
            {
                Id = bookingViewModel.Id,
                Name = bookingViewModel.Name,
                BookingDateTime = bookingViewModel.BookingDateTime,
                Flexibility = (Flexibility)bookingViewModel.Flexibility,
                VehicleSize = (VehicleSize)bookingViewModel.VehicleSize,
                ContactNumber = bookingViewModel.ContactNumber,
                EmailAddress = bookingViewModel.EmailAddress
            };
        }

        public AdminBookingsViewModel CreateAdminBookingsViewModel(IEnumerable<BookingDTO> bookings)
        {
            return new AdminBookingsViewModel
            {
                BookingViewModel = bookings.Select(CreateBookingViewModel).ToList()
            };
        }

        public BookingViewModel CreateBookingViewModel(BookingDTO booking)
        {
            return new BookingViewModel
            {
                Id = booking.Id,
                CreatedAt = booking.CreatedAt,
                UpdatedAt = booking.UpdatedAt,
                Name = booking.Name,
                BookingDateTime = booking.BookingDateTime,
                Flexibility = (ViewModel.Flexibility) booking.Flexibility,
                VehicleSize = (ViewModel.VehicleSize) booking.VehicleSize,
                ContactNumber = booking.ContactNumber,
                EmailAddress = booking.EmailAddress,
                Approved = booking.Approved
            };
        }

    }
}
