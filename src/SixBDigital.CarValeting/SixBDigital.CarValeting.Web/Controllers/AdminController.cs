using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SixBDigital.CarValeting.Core.DTOs;
using SixBDigital.CarValeting.Core.Entities;
using SixBDigital.CarValeting.Core.Interfaces;
using SixBDigital.CarValeting.Web.Factories;
using SixBDigital.CarValeting.Web.Models;
using SixBDigital.CarValeting.Web.ViewModel;

namespace SixBDigital.CarValeting.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService<User> _userService;
        private readonly IBookingService<Booking> _bookingService;
        private readonly BookingFactory _bookingFactory;

        public AdminController(IUserService<User> userService, IBookingService<Booking> bookingService,
            BookingFactory bookingFactory)
        {
            _userService = userService;
            _bookingService = bookingService;
            _bookingFactory = bookingFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var isAuthenticated = _userService.IsPasswordValid(loginModel.UserName, loginModel.Password);

            if (isAuthenticated)
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginModel.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity));

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
        }

        public IActionResult Index()
        {
            var bookings = _bookingService.GetAllBookings();

            var viewModel = _bookingFactory.CreateAdminBookingsViewModel(bookings);

            return View(viewModel);
        }
        
        [HttpPost("ToggleApproval/{id}")]
        public async Task<IActionResult> ToggleApproval(int id)
        {
            await _bookingService.ToggleApprovalAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _bookingService.GetBookingAsync(id);

            var viewModel = _bookingFactory.CreateBookingViewModel(booking);

            return View(viewModel);
        }

        [HttpPost("EditBooking")]
        public async Task<IActionResult> EditBooking(BookingViewModel booking)
        {
            if (!ModelState.IsValid)
            {
                return View(booking);
            }

            await _bookingService.UpdateBooking(_bookingFactory.CreateUpdateBookingDto(booking));

            return RedirectToAction("Index");
        }

        [HttpPost("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return RedirectToAction("Index");
        }
    }
}
