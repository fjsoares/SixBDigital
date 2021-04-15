using SixBDigital.CarValeting.Core.Entities;

namespace SixBDigital.CarValeting.Core.Interfaces
{
    public interface IUserService<in T> : IValidation<T> where T : BaseEntity<T>
    {
        bool IsPasswordValid(string username, string password);
    }
}
