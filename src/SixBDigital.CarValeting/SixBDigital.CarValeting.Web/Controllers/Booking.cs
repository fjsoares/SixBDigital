using Microsoft.AspNetCore.Mvc;
using SixBDigital.CarValeting.Web.ViewModel;

namespace SixBDigital.CarValeting.Web.Controllers
{
    public class Booking : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View(new CreateBooking());
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CreateBooking createBooking)
        {
            if (!ModelState.IsValid)
            {
                return View(createBooking);
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
