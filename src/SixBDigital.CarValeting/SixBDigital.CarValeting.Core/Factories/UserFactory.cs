using SixBDigital.CarValeting.Core.Entities;

namespace SixBDigital.CarValeting.Core.Factories
{
    public class UserFactory
    {
        public User CreateNewUser(string username, string password) =>
            new User {UserName = username, Password = password};

    }
}
