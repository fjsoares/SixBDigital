using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SixBDigital.CarValeting.Core.DTOs;
using SixBDigital.CarValeting.Core.Entities;
using SixBDigital.CarValeting.Core.Factories;
using SixBDigital.CarValeting.Core.Interfaces;
using SixBDigital.CarValeting.Core.Validators;

namespace SixBDigital.CarValeting.Core.Services
{
    public class BookingService : IBookingService<Booking>
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

            Validate(booking);

            var result = await _bookingRepository.CreateAsync(booking);

            return result;
        }

        /// <summary>
        /// Get all bookings
        /// </summary>
        /// <returns>Get all bookings</returns>
        public IEnumerable<BookingDTO> GetAllBookings()
        {
            var bookings = _bookingRepository.GetAll();

            return bookings.Select(x => _bookingFactory.CreateBookingDTO(x));
        }

        /// <summary>
        /// Approve or not approve
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task ToggleApprovalAsync(int id)
        {
            var booking = await _bookingRepository.GetAsync(id);

            if (booking != null)
            {
                booking.Approved = !booking.Approved;
                await _bookingRepository.UpdateAsync(booking);
            }
        }

        /// <summary>
        /// Delete booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteBookingAsync(int id)
        {
            await _bookingRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Update booking
        /// </summary>
        /// <param name="updateBooking"></param>
        /// <returns>Updated booking</returns>
        public async Task<BookingDTO> UpdateBooking(UpdateBookingDTO updateBooking)
        {
            if (updateBooking == null)
            {
                throw new ArgumentNullException(nameof(updateBooking));
            }

            var booking = _bookingFactory.CreateBooking(updateBooking);

            Validate(booking);

           await _bookingRepository.UpdateAsync(booking);

            var updated = await _bookingRepository.GetAsync(updateBooking.Id);

            return _bookingFactory.CreateBookingDTO(updated);
        }

        /// <summary>
        /// Get a booking given the id
        /// </summary>
        /// <param name="id">Id of the booking</param>
        /// <returns>Booking</returns>
        public async Task<BookingDTO> GetBookingAsync(int id)
        {
            var booking = await _bookingRepository.GetAsync(id);

            return _bookingFactory.CreateBookingDTO(booking);
        }

        public void Validate(Booking entity)
        {
            var validationResults = new BookingValidator().Validate(entity);
            if (!validationResults.IsValid)
            {
                throw new ValidationException("Booking is invalid", validationResults.Errors);
            }
        }
    }
}
