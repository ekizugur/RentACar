using FluentValidation;
using Microsoft.AspNetCore.Identity;
using RentACar.Data.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.FluentValidations
{
    public class RegisterValidator:AbstractValidator<UserRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email adresi zorunlu.").EmailAddress().WithMessage("Lütfen bir Email adresi giriniz.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim alanı boş geçilemez");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim alanı boş geçilemez");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası alanı boş geçilemez");
        }
    }
   
}
