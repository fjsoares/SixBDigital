using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SixBDigital.CarValeting.Core.Entities;
using SixBDigital.CarValeting.Web.Factories;
using SixBDigital.CarValeting.Core.Interfaces;
using SixBDigital.CarValeting.Web.ViewModel;

namespace SixBDigital.CarValeting.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService<Booking> _bookingService;
        private readonly BookingFactory _bookingFactory;

        public BookingController(IBookingService<Booking> bookingService, BookingFactory bookingFactory)
        {
            _bookingService = bookingService;
            _bookingFactory = bookingFactory;
        }

        // GET: Booking
        public ActionResult Index()
        {
            return View(new CreateBookingViewModel());
        }

        // POST: Booking/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(CreateBookingViewModel createBookingViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createBookingViewModel);
            }

            var bookingDto = _bookingFactory.CreateBookingDto(createBookingViewModel);

            await _bookingService.CreateBookingAsync(bookingDto);

            return View("CreateSuccess");
        }
    }
}
