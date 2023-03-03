using FluentValidation;
using RentACar.Data.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.FluentValidations
{
    public class LoginValidator:AbstractValidator<UserLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email adresi zorunlu.").EmailAddress().WithMessage("Lütfen bir Email adresi giriniz.");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
        }
    }
}
