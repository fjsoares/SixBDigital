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
    }
}
