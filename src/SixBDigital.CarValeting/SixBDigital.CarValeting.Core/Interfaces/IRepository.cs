using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SixBDigital.CarValeting.Core.Entities;

namespace SixBDigital.CarValeting.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity<T>
    {
        Task<int> CreateAsync(T entity);
        Task<T> GetAsync(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        T GetBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
    }
}
