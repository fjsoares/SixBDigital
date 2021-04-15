using SixBDigital.CarValeting.Core.Entities;

namespace SixBDigital.CarValeting.Core.Interfaces
{
    public interface IValidation<in T> where T : BaseEntity<T>
    {
        void Validate(T entity);
    }
}
