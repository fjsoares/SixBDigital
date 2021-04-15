using System.Collections.Generic;
using System.Threading.Tasks;
using SixBDigital.CarValeting.Core.DTOs;
using SixBDigital.CarValeting.Core.Entities;

namespace SixBDigital.CarValeting.Core.Interfaces
{
    public interface IBookingService<in T> : IValidation<T> where T : BaseEntity<T>
    {
        Task<int> CreateBookingAsync(CreateBookingDTO createBooking);
        IEnumerable<BookingDTO> GetAllBookings();
        Task ToggleApprovalAsync(int id);
        Task DeleteBookingAsync(int id);
        Task<BookingDTO> UpdateBooking(UpdateBookingDTO updateBooking);
        Task<BookingDTO> GetBookingAsync(int id);
    }
}