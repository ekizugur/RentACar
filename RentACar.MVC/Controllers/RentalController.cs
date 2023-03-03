using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using RentACar.Data.DTOs;
using RentACar.Data.UnitOfWorks;
using RentACar.Entity.Entities;
using RentACar.Service.Services.Abstractions;
using System.Web;


namespace RentACar.MVC.Controllers
{
    [Authorize]
    public class RentalController : Controller
    {
        private readonly ICarService carService;
        private readonly IUserService userService;
        private readonly IRentalService rentalService;
        private readonly IMapper mapper;
        private readonly IPaymentService paymentService;
        private readonly IToastNotification toast;

        public RentalController(ICarService carService,IUserService userService,IRentalService rentalService,IMapper mapper,IPaymentService paymentService,IToastNotification toast)
        {
            this.carService = carService;
            this.userService = userService;
            this.rentalService = rentalService;
            this.mapper = mapper;
            this.paymentService = paymentService;
            this.toast = toast;
        }



        
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Rent()
        {
            var RentACar = (DateTime)TempData["RentACar"];
            var EndTime = (DateTime)TempData["EndTime"];
            var TotalPrice = TempData["TotalPrice"];
            var carId = (Guid)TempData["carId"];
            var paymentInfoId = (Guid)TempData["PaymentInfoId"];
            var transactionId = TempData["paymentTransactionId"].ToString();
            var paymentId = TempData["PaymentId"].ToString();

            var userId = userService.GetUserId();
            var car = await rentalService.GetCarById(carId); 
            var payment= await paymentService.GetPaymentById(paymentInfoId);

            var rent = new CarRentalDto
            {
                CarId = carId,
                RentDate = RentACar,
                ReturnDate = EndTime,
                UserId = Guid.Parse(userId),
                TotalPrice = Convert.ToInt32(TotalPrice),
                Car = car,
                PaymentInfoId = paymentInfoId,
                PaymentId = paymentId,
                PaymentInfo = payment,
                Id = Guid.NewGuid(),
                IsActive = true,
                TransactionId = transactionId,
                RefundRequest=false
                
        };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await rentalService.Rent(rent);
                return View(rent);
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                TempData["RentError"] = errorMessage;
                return RedirectToAction("Detail", "Car", new RouteValueDictionary(new
                {
                    action = "Rent",
                    controller = "Rental",
                    RentACar = RentACar,
                    EndTime = EndTime,
                    TotalPrice = TotalPrice,
                    carId = carId
                }));
            }


        }
        [HttpPost]
        public async Task<IActionResult> RefundRequestUser(Guid rentalId)
        {
            var rent = await rentalService.RentalCancellationRequest(rentalId);
            toast.AddSuccessToastMessage("İade talebiniz alındı yöneticilerin onaylaması halinde paranız kartınıza iade edilecektir.", new ToastrOptions { Title = "İşlem başarılı" });
            return RedirectToAction("Profile", "User");
        }



    }
}
