using Microsoft.AspNetCore.Mvc;
using SixBDigital.CarValeting.Web.ViewModel;

namespace SixBDigital.CarValeting.Web.Controllers
{
    public class Booking : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View(new CreateBookingViewModel());
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CreateBookingViewModel createBookingViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createBookingViewModel);
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Index();
            }
        }
    }
}
