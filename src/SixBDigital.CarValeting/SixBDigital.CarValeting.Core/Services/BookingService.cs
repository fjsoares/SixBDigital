using System;
using System.Threading.Tasks;
using FluentValidation;
using SixBDigital.CarValeting.Core.DTOs;
using SixBDigital.CarValeting.Core.Entities;
using SixBDigital.CarValeting.Core.Factories;
using SixBDigital.CarValeting.Core.Interfaces;
using SixBDigital.CarValeting.Core.Validators;

namespace SixBDigital.CarValeting.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepository;
        private readonly BookingFactory _bookingFactory;

        public BookingService(IRepository<Booking> bookingRepository, BookingFactory bookingFactory)
        {
            _bookingRepository = bookingRepository;
            _bookingFactory = bookingFactory;
        }

        /// <summary>
        /// Create a new booking in the database
        /// </summary>
        /// <param name="createBooking">New booking</param>
        /// <returns></returns>
        public async Task<int> CreateBookingAsync(CreateBookingDTO createBooking)
        {
            if (createBooking == null)
            {
                throw new ArgumentNullException(nameof(createBooking));
            }

            var booking = _bookingFactory.CreateBooking(createBooking);

            ValidateBooking(booking);

            var result = await _bookingRepository.CreateAsync(booking);

            return result;
        }

        private void ValidateBooking(Booking booking)
        {
            var validationResults = new BookingValidator().Validate(booking);
            if (!validationResults.IsValid)
            {
                throw new ValidationException("Booking is invalid", validationResults.Errors);
            }
        }
    }
}
