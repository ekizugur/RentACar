using FluentValidation;
using RentACar.Data.DTOs.Payments;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.FluentValidations
{
    public class PaymentValidator:AbstractValidator<PaymentInfoDto>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.PaymentAmount).NotEmpty().WithMessage("Toplam tutar alanı boş geçilemez");
        }
    }
}
