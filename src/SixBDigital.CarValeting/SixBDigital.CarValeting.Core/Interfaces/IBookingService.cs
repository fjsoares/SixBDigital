using System.Threading.Tasks;

namespace SixBDigital.CarValeting.Core.Interfaces
{
    public interface IBookingService
    {
        public Task<int> CreateBooking() { get; set; }
    }
}