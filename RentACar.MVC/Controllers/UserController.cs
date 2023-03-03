using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RentACar.Data.DTOs;
using RentACar.Data.DTOs.Cars;
using RentACar.Data.DTOs.Users;
using RentACar.Entity.Entities;
using RentACar.Service.FluentValidations;
using RentACar.Service.Services.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IConfiguration config;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;
        private readonly IMailService mailService;
        private readonly IUserService userService;
        private readonly IRentalService rentalService;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration config, IMapper mapper, IToastNotification toast, IMailService mailService, IUserService userService, IRentalService rentalService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.config = config;
            this.mapper = mapper;
            this.toast = toast;
            this.mailService = mailService;
            this.userService = userService;
            this.rentalService = rentalService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Home/Index");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var validator = new LoginValidator();
            var result = await validator.ValidateAsync(userLoginDto);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return View();
            }
            var user = await userManager.FindByEmailAsync(userLoginDto.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email adresi veya parola yanlış");
                return View();
            }
            if (!await userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Giriş yapabilmek için lütfen Email adresinizi onaylayınız");
                return View();
            }
            var signInResult = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
            
            if (signInResult.Succeeded)
            {
                toast.AddSuccessToastMessage("Giriş işlemi başarılı", new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Email adresi veya parola yanlış");
                return View();
            }
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            toast.AddSuccessToastMessage("Çıkış işlemi başarılı", new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Home/Index");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {

            var registerValidator = new RegisterValidator();
            var result = await registerValidator.ValidateAsync(userRegisterDto);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return View();
            }
            var user = new AppUser
            {
                Email = userRegisterDto.Email,
                NormalizedEmail = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                UserName = userRegisterDto.Email,
                NormalizedUserName = userRegisterDto.Email,
                PhoneNumber = userRegisterDto.PhoneNumber,
                

            };
            var createdUser = await userManager.CreateAsync(user, userRegisterDto.Password);
            if (createdUser.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");

                toast.AddSuccessToastMessage("Kayıt işlemi başarıyla tamamlandı. Email adresinizi kontrol ediniz.", new ToastrOptions { Title = "Başarılı" });
                var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail", "User", new
                {
                    UserId = user.Id,
                    token = code
                });
                await mailService.SendMessageAsync(user.Email, "Email Confirm for Rent A Car System", $"<a href='{config.GetSection("SiteLink").Value}{url}'>Please click the link to confirm your email account.</a>");
                return RedirectToAction("Login", "User", new { Area = "" });

            }

            foreach (var item in createdUser.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(userRegisterDto);
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null || token == null)
            {
                ModelState.AddModelError("", "Kullanıcı veya Token Geçersiz.");
                return View();
            }

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    toast.AddAlertToastMessage(error.Description, new ToastrOptions { Title = "Hatalı İşlem" });
                }

            }
            else
            {
                toast.AddSuccessToastMessage("Email doğrulama işlemi başarıyla gerçekleştirildi", new ToastrOptions { Title = "Başarılı" });
            }
            return RedirectToAction("Login", "User");

        }
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var userId = userService.GetUserId();
            var user = await userManager.Users.Include(u => u.Image).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));
            var identityUser = mapper.Map<UserDto>(user);
            if (user == null) return NotFound();
            // Kullanıcının kiralama bilgilerini çek
            var rentals = await rentalService.GetRentalsByUserId(Guid.Parse(userId));
            ViewData["Rentals"] = rentals;

            return View(identityUser);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserDto userDto)
        {

            if (ModelState.IsValid)
            {
                var userId = userService.GetUserId();
                var user = await userManager.Users.Include(u => u.Image).FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));
                var oldEmail = user.Email;
                user.PhoneNumber = userDto.PhoneNumber;
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                if (user.Email != userDto.Email)
                {
                    user.EmailConfirmed = false;
                    user.Email = userDto.Email;
                    user.UserName = userDto.Email;

                }

                if (userDto.Photo != null)
                {
                    await userService.ProfileUpdateAsync(userDto);
                }

                var result = await userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        TempData["ProfileUpdateError"] = error.Description;
                    }

                    return RedirectToAction("Profile", "User");
                }
                if (oldEmail != user.Email)
                {

                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);



                    var url = Url.Action("ConfirmEmail", "User", new
                    {
                        UserId = user.Id,
                        token = code
                    });
                    await mailService.SendMessageAsync(user.Email, "Email Confirm for Rent A Car System", $"<a href='{config.GetSection("SiteLink").Value}{url}'>Please click the link to confirm your email account.</a>");
                    toast.AddSuccessToastMessage("Eposta başarıyla değiştirildi işlemlere devam edebilmek için. Lütfen yeni email adresinizi onaylayınız.", new ToastrOptions { Title = "Başarılı" });

                }
                await userManager.UpdateSecurityStampAsync(user);
                await signInManager.SignOutAsync();
                await signInManager.SignInAsync(user, true);
            }

            return RedirectToAction("Profile", "User");

        }
        public async Task<IActionResult> ChangePassword(ResetPasswordDto resetPasswordDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                
                if (await userManager.CheckPasswordAsync(user, resetPasswordDto.CurrentPassword))
                {
                    if(resetPasswordDto.NewPassword == resetPasswordDto.ConfirmNewPassword) { 
                    var result = await userManager.ChangePasswordAsync(user, resetPasswordDto.CurrentPassword, resetPasswordDto.NewPassword);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                                TempData["ProfileUpdateError"] = error.Description;
                            }
                        }
                        else
                        {

                            toast.AddSuccessToastMessage("Şifreniz başarıyla değiştirildi.", new ToastrOptions { Title = "Başarılı" });
                        }
                        await userManager.UpdateSecurityStampAsync(user);
                        await signInManager.SignOutAsync();
                        await signInManager.SignInAsync(user, true);
                    }
                    else
                    {
                        TempData["ProfileUpdateError"] = "Yeni şifre alanları birbiri ile uyuşmuyor.";
                    }
                    
                }
                else
                {
                    TempData["ProfileUpdateError"] = "Şifre değiştirebilmek için lütfen güncel şifrenizi doğru şekilde giriniz.";
                    toast.AddAlertToastMessage("Eski şifrenizi hatalı girdiniz.", new ToastrOptions { Title = "Hata" });
                }

            }

            return RedirectToAction("Profile");
        }
        [HttpGet]
        public async Task<IActionResult> Rentals(CarRentalDto carRentalDto)
        {
            var userId=userService.GetUserId();
            var rentals = await rentalService.GetRentalsByUserId(Guid.Parse(userId));
            if(rentals.Count == 0)
            {
                TempData["NonRental"] = "Şu ana kadar kiralama işlemi yapılmamış.";
            }
            return PartialView("_PartialRents", rentals);

        }
    }


}
