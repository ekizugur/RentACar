using FluentValidation;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.FluentValidations
{
    public class CarValidator:AbstractValidator<Car> //ayrı ayrı validation oluşturmamak için add ve update işlemi için mapleme yapacağız.
    {
        public CarValidator()
        {
            RuleFor(x => x.Price).NotEmpty().NotNull().GreaterThan(200).WithName("Fiyat");
            RuleFor(x => x.FuelType).NotEmpty().NotNull().MinimumLength(3).WithName("Yakıt Tipi");
            RuleFor(x => x.ProductionYear).NotEmpty().NotNull().GreaterThan(1970).WithName("Araç Üretim Yılı");
            RuleFor(x => x.Model).NotEmpty().NotNull().WithMessage("Araç modelini giriniz.");
            RuleFor(x => x.Kilometer).NotNull().GreaterThan(0).NotEmpty().WithMessage("Kilometre değerini giriniz.");
            RuleFor(x => x.Description).NotNull().NotNull().MinimumLength(50).WithName("Araç Açıklaması");
            


        }
    }
}
