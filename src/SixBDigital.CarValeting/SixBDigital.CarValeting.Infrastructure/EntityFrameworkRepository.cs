using System.Threading.Tasks;
using SixBDigital.CarValeting.Core.Entities;
using SixBDigital.CarValeting.Core.Interfaces;

namespace SixBDigital.CarValeting.Infrastructure
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : BaseEntity<T>
    {
        private readonly SixBDigitalCarValetingContext _context;

        public EntityFrameworkRepository(SixBDigitalCarValetingContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(T entity)
        {
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.FindAsync<T>(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
