using System;
using System.Linq.Expressions;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SixBDigital.CarValeting.Core.Entities;
using SixBDigital.CarValeting.Core.Interfaces;
using SixBDigital.CarValeting.Core.Services;
using SixBDigital.CarValeting.Core.Test.Attributes;
using Xunit;

namespace SixBDigital.CarValeting.Core.Test.Services
{
    public class UserServiceTest
    {
        [Theory]
        [AutoMockedData]
        public void IsPasswordValid_ShouldValidationException_WhenUsernameIsEmpty(
            string password,
            UserService userService)
        {
            // ARRANGE
            string username = null;

            // ACT

            Func<bool> result = () => userService.IsPasswordValid(username, password);

            // ASSERT

            result.Should().Throw<ValidationException>()
                .WithMessage("User is invalid");
        }

        [Theory]
        [AutoMockedData]
        public void IsPasswordValid_ShouldValidationException_WhenPasswordIsEmpty(
            string username,
            UserService userService)
        {
            // ARRANGE
            string password = null;

            // ACT

            Func<bool> result = () => userService.IsPasswordValid(username, password);

            // ASSERT

            result.Should().Throw<ValidationException>()
                .WithMessage("User is invalid");
        }

        [Theory]
        [AutoMockedData]
        public void IsPasswordValid_ShouldReturnFalse_WhenUserIsNotFound(
            string username, string password,
            [Frozen] IRepository<User> repository,
            UserService userService)
        {
            // ARRANGE
            repository.GetBy(Arg.Any<Expression<Func<User, bool>>>()).ReturnsNull();

            // ACT

           var result = userService.IsPasswordValid(username, password);

            // ASSERT

            result.Should().BeFalse();
        }
    }
}
