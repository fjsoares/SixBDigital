using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SixBDigital.CarValeting.Core.DTOs;
using SixBDigital.CarValeting.Core.Entities;
using SixBDigital.CarValeting.Core.Factories;
using SixBDigital.CarValeting.Core.Interfaces;
using SixBDigital.CarValeting.Core.Services;
using SixBDigital.CarValeting.Core.Test.Attributes;
using Xunit;

namespace SixBDigital.CarValeting.Core.Test.Services
{
    public class BookingServiceTest
    {
        [Theory]
        [AutoMockedData]
        public void CreateBookingAsync_ShouldThrowArgumentNullException_WhenArgumentIsNull(
            BookingService bookingService)
        {
            // ARRANGE
            CreateBookingDTO createBooking = null;

            // ACT

            Func<Task<int>> result = async () => await bookingService.CreateBookingAsync(createBooking);

            // ASSERT

            result.Should().Throw<ArgumentNullException>()
                .WithMessage("*createBooking*");
        }

        [Theory]
        [AutoMockedData]
        public void CreateBookingAsync_ShouldValidationException_WhenNameIsEmpty(
            CreateBookingDTO createBooking,
            BookingService bookingService)
        {
            // ARRANGE
            createBooking.Name = "";
            createBooking.EmailAddress = "ssahhd@gmail.com";

            // ACT

            Func<Task<int>> result = async () => await bookingService.CreateBookingAsync(createBooking);

            // ASSERT

            result.Should().Throw<ValidationException>()
                .WithMessage("Booking is invalid");
        }

        [Theory]
        [AutoMockedData]
        public void CreateBookingAsync_ShouldValidationException_WhenContactNumberIsEmpty(
            CreateBookingDTO createBooking,
            BookingService bookingService)
        {
            // ARRANGE
            createBooking.Name = "nbnb";
            createBooking.EmailAddress = "ssahhd@gmail.com";
            createBooking.ContactNumber = "";

            // ACT

            Func<Task<int>> result = async () => await bookingService.CreateBookingAsync(createBooking);

            // ASSERT

            result.Should().Throw<ValidationException>()
                .WithMessage("Booking is invalid");
        }

        [Theory]
        [AutoMockedData]
        public void CreateBookingAsync_ShouldValidationException_WhenEmailAddressIsEmpty(
            CreateBookingDTO createBooking,
            BookingService bookingService)
        {
            // ARRANGE
            createBooking.Name = "nbnb";
            createBooking.EmailAddress = "";

            // ACT

            Func<Task<int>> result = async () => await bookingService.CreateBookingAsync(createBooking);

            // ASSERT

            result.Should().Throw<ValidationException>()
                .WithMessage("Booking is invalid");
        }


        [Theory]
        [AutoMockedData]
        public void CreateBookingAsync_ShouldValidationException_WhenEmailAddressIsInvalid(
                CreateBookingDTO createBooking,
                BookingService bookingService)
        {
            // ARRANGE
            createBooking.Name = "nbnb";
            
            // ACT
            
            Func<Task<int>> result = async () => await bookingService.CreateBookingAsync(createBooking);
            
            // ASSERT
            
            result.Should().Throw<ValidationException>()
                    .WithMessage("Booking is invalid");
        }

        [Theory]
        [AutoMockedData]
        public async Task CreateBookingAsync_ShouldAddBooking_WhenThereIsNoErrors(
            CreateBookingDTO createBooking,
            [Frozen] IRepository<Booking> bookingRepository,
            BookingService bookingService)
        {
            // ARRANGE
            createBooking.EmailAddress = "ssahhd@gmail.com";
            bookingRepository.CreateAsync(Arg.Any<Booking>()).Returns(1);

            // ACT

            var result = await bookingService.CreateBookingAsync(createBooking);

            // ASSERT

            result.Should().Be(1);
        }

        [Theory]
        [AutoMockedData]
        public void GetAllBookings_ShouldReturnAllBookings_WhenThereIsRecords(
            List<Booking> bookings,
            [Frozen] IRepository<Booking> bookingRepository,
            BookingService bookingService)
        {
            // ARRANGE

            bookingRepository.GetAll().Returns(bookings);

            // ACT

            var result = bookingService.GetAllBookings();

            // ASSERT

            result.Should().HaveCount(3);
            result.Should().BeEquivalentTo(bookings.Select(x => new BookingFactory().CreateBookingDTO(x)));
        }

        [Theory]
        [AutoMockedData]
        public async Task ToggleApprovalAsync_ShouldNotToggle_WhenThereBookingIsNotFoundInTheDatabase(
            int id,
            [Frozen] IRepository<Booking> bookingRepository,
            BookingService bookingService)
        {
            // ARRANGE

            bookingRepository.GetAsync(id).ReturnsNull();

            // ACT

            await bookingService.ToggleApprovalAsync(id);

            // ASSERT

            await bookingRepository.Received(0).UpdateAsync(Arg.Any<Booking>());
        }

        [Theory]
        [AutoMockedData]
        public async Task ToggleApprovalAsync_ShouldToggle_WhenThereBookingInTheDatabase(
            Booking booking,
            [Frozen] IRepository<Booking> bookingRepository,
            BookingService bookingService)
        {
            // ARRANGE

            bookingRepository.GetAsync(booking.Id).Returns(booking);

            // ACT

            await bookingService.ToggleApprovalAsync(booking.Id);

            // ASSERT

            await bookingRepository.Received(1).UpdateAsync(booking);
        }

        [Theory]
        [AutoMockedData]
        public void GetBookingAsync_ShouldThrowArgumentException_WhenIdIsNotFound(
            int id,
            [Frozen] IRepository<Booking> bookingRepository,
            BookingService bookingService)
        {
            // ARRANGE
            bookingRepository.GetAsync(id).ReturnsNull();

            // ACT

            Func<Task<BookingDTO>> result = async () => await bookingService.GetBookingAsync(id);

            // ASSERT

            result.Should().Throw<ArgumentException>()
                .WithMessage("*id*");
        }

        [Theory]
        [AutoMockedData]
        public async Task GetBookingAsync_ShouldReturnBooking_WhenIdIsIsFound(
            Booking booking,
            [Frozen] IRepository<Booking> bookingRepository,
            BookingService bookingService)
        {
            // ARRANGE
            bookingRepository.GetAsync(booking.Id).Returns(booking);

            // ACT

            var result = await bookingService.GetBookingAsync(booking.Id);

            // ASSERT

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new BookingFactory().CreateBookingDTO(booking));
        }

    }
    
}
