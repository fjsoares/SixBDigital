using FluentValidation;
using SimpleCrypto;
using SixBDigital.CarValeting.Core.Entities;
using SixBDigital.CarValeting.Core.Factories;
using SixBDigital.CarValeting.Core.Interfaces;
using SixBDigital.CarValeting.Core.Validators;

namespace SixBDigital.CarValeting.Core.Services
{
    public class UserService : IUserService<User>
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserFactory _userFactory;

        public UserService(IRepository<User> userRepository, UserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
        }

        /// <summary>
        /// Check if the password is valid
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>If password matches</returns>
        public bool IsPasswordValid(string username, string password)
        {
            var user = _userFactory.CreateNewUser(username, password);

            Validate(user);

            var foundUser = _userRepository.GetBy(x => x.UserName == user.UserName);

            if (foundUser == null)
                return false;

            var cryptoService = new PBKDF2();
            string hashedPassword = cryptoService.Compute(password, foundUser.Salt);

            bool isPasswordValid = cryptoService.Compare(foundUser.Password, hashedPassword);

            return isPasswordValid;
        }

        public void Validate(User entity)
        {
            var validationResults = new UserValidator().Validate(entity);
            if (!validationResults.IsValid)
            {
                throw new ValidationException("User is invalid", validationResults.Errors);
            }
        }
    }
}
