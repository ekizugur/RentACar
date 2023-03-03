using AutoMapper;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data.DTOs.Payments;
using RentACar.Data.UnitOfWorks;
using RentACar.Entity.Entities;
using RentACar.Service.Services.Abstractions;
using System.Globalization;


namespace RentACar.MVC.Controllers
{

    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IRentalService rentalService;
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPaymentService paymentService;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly IPaymentOptionService paymentOptionService;

        public PaymentController(IRentalService rentalService,IUserService userService,IUnitOfWork unitOfWork,IPaymentService paymentService,IMapper mapper,UserManager<AppUser> userManager,IPaymentOptionService paymentOptionService)
        {
            this.rentalService = rentalService;
            this.userService = userService;
            this.unitOfWork = unitOfWork;
            this.paymentService = paymentService;
            this.mapper = mapper;
            this.userManager = userManager;
            this.paymentOptionService = paymentOptionService;
        }
        public async Task<IActionResult> Index(DateTime RentACar, DateTime EndTime,decimal TotalPrice, Guid Id,string CardNumber,string ExpireMonth,string ExpireYear, string Cvc,string CardHolderName)
        {



            var price = TotalPrice.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            var car = await rentalService.GetCarById(Id);
            var userId = userService.GetUserId();
            var user=await userManager.FindByIdAsync(userId);

            var options = paymentOptionService.GetOptions();

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = price;
            request.PaidPrice = price;
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = CardHolderName;
            paymentCard.CardNumber = CardNumber.Replace("-","");
            paymentCard.ExpireMonth = ExpireMonth;
            paymentCard.ExpireYear = ExpireYear;
            paymentCard.Cvc = Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;
            

            Buyer buyer = new Buyer();
            buyer.Id = userId;
            buyer.Name = user.FirstName;
            buyer.Surname = user.LastName;
            buyer.GsmNumber = user.PhoneNumber;
            buyer.Email = user.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Fatih Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Uğur Ekiz";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Uğur Ekiz";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = car.Id.ToString();
            firstBasketItem.Name = car.Brand.Name+ car.Model;
            firstBasketItem.Category1 = car.Category.CategoryName;
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = price;
            basketItems.Add(firstBasketItem);

            request.BasketItems = basketItems;
            

            try
            {
                
               var isAvaliable=await rentalService.isAvailable(Id, RentACar, EndTime);
                if(isAvaliable)
                {
                    Payment payment = Payment.Create(request, options);
                    var paymentId = payment.PaymentId;
                    string paymentTransactionId = payment.PaymentItems[0].PaymentTransactionId;



                    if (payment.Status == "success")
                    {

                        
                        // ödeme başarılı
                        var paymentInfo = new PaymentInfoDto
                        {
                            Id = Guid.NewGuid(),
                            PaymentAmount = TotalPrice,
                            PaymentDate = DateTime.Now,
                            PaymentStatus = true,
                            CreatedBy = user.Email,
                            CreatedDate = DateTime.Now,
                            UserId = Guid.Parse(userId),
                            PaymentId= paymentId,
                            
                        };
                        await paymentService.addPayment(paymentInfo);
                        

                        TempData["RentACar"] = RentACar;
                        TempData["EndTime"] = EndTime;
                        TempData["TotalPrice"] = TotalPrice.ToString();
                        TempData["carId"] = Id;
                        TempData["PaymentId"] = paymentId;
                        TempData["PaymentInfoId"] = paymentInfo.Id;
                        TempData["paymentTransactionId"] = paymentTransactionId;
                        return RedirectToAction("Rent", "Rental");
                    }
                    else
                    {
                        // ödeme başarısız
                        var errorMessage = "Ödeme işlemi başarısız. Lütfen tekrar deneyin.";
                        if (payment.ErrorMessage != null)
                        {
                            
                            errorMessage = payment.ErrorMessage;
                            TempData["RentError"] = errorMessage;
                        }
                        
                    }
                 
                    return RedirectToAction("Detail", "Car", new { CarId = car.Id });
                }
            }
            catch (Exception ex)
            {
                TempData["RentError"] = ex.Message;
                return RedirectToAction("Detail", "Car", new { CarId = car.Id });
            }

            TempData["RentError"] = "Araç belirlediğiniz tarihler arasında zaten kiralanmış. Lütfen tarihleri düzenleyiniz veya farklı araçlarımıza bakınız.";
            return RedirectToAction("Detail", "Car", new { CarId = car.Id });

        }
       
        // POST: Payment/Refund
        [HttpPost]
        public async Task<IActionResult> RefundRequest(string paymentTransactionId, decimal amount,Guid rentalId)
        {
            try
            {
                var options = paymentOptionService.GetOptions();

                var request = new CreateRefundRequest
                {
                    ConversationId = "123456789",
                    Locale = Locale.TR.ToString(),
                    PaymentTransactionId = paymentTransactionId,
                    Price = amount.ToString().Replace(",", "."),
                    Ip = "85.34.78.112",
                    Currency = Currency.TRY.ToString()
                };

                Refund refund = Refund.Create(request, options);


                if (refund.Status == "success")
                {
                    var result = await rentalService.RentalCancellation(rentalId);
                    if (result == true)
                    {
                        TempData["RentCancellation"] = "Araç kiralama iptal işlemi gerçekleşti ve ödeme iade edildi.";
                        return RedirectToAction("RefundCancellationRequests", "Rental", new {Area="Admin"});
                    }
                    TempData["RentCancellation"] = "Hata Oluştu.";
                    return RedirectToAction("RefundCancellationRequests", "Rental", new { Area = "Admin" });
                }
                else
                {
                    
                    return RedirectToAction("Error", "Home"); 
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

    }
}
