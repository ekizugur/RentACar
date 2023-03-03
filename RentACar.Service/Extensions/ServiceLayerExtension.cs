using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Data.DTOs.Cars;
using RentACar.Data.DTOs;
using RentACar.Entity.Entities;
using RentACar.Service.FluentValidations;
using RentACar.Service.Helpers.Images;
using RentACar.Service.Services.Abstractions;
using RentACar.Service.Services.Concretes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace RentACar.Service.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly=Assembly.GetExecutingAssembly();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IImageHelper,ImageHelper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRentalService, RentalService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<RoleManager<AppRole>>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentOptionService, PaymentOptionService>();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Car, CarDto>();
                cfg.CreateMap<Rental, CarRentalDto>();
            });
            
            var mapper = config.CreateMapper();
            services.AddAutoMapper(assembly);

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<CarValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            }
            );
            // appsettings.json dosyasındaki değerleri IConfiguration nesnesi olarak kullanmak için
            

            return services;
        }
    }
}
