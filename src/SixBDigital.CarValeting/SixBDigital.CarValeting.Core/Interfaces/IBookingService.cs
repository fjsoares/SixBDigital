using System.Threading.Tasks;
using SixBDigital.CarValeting.Core.DTOs;

namespace SixBDigital.CarValeting.Core.Interfaces
{
    public interface IBookingService
    {
        Task<int> CreateBookingAsync(CreateBookingDTO createBooking);
    }
}