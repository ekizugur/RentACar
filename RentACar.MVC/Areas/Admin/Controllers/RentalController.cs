using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data.DTOs;
using RentACar.Service.Services.Abstractions;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RentalController : Controller
    {
        private readonly IRentalService rentalService;

        public RentalController(IRentalService rentalService)
        {
            this.rentalService = rentalService;
        }
        public async Task<IActionResult> Index()
        {
            var rentals=await rentalService.GetAllRentalsAsync();
            return View(rentals);
        }
        [HttpGet]
        public async Task<IActionResult> RefundCancellationRequests()
        {
            var rentals=await rentalService.GetRefundRequestsAsync();
            return View(rentals);
        }

        [HttpPost]
        public async Task<IActionResult> Rent(CarRentalDto carRentalDto)
        {
            return View();
        }

    }
}
