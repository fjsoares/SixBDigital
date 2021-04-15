using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using SixBDigital.CarValeting.Core.DTOs;
using SixBDigital.CarValeting.Core.Entities;
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

    }
    
}
