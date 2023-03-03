using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentACar.BgServices.Services;
using RentACar.Data.Context;
using RentACar.Data.Extensions;
using RentACar.Entity.Entities;
using RentACar.Service.CustomValidations;
using RentACar.Service.Extensions;
using Microsoft.AspNetCore.Hosting;
using RentACar.Service.Services.Abstractions;
using RentACar.Service.Services.Concretes;
using RentACar.Service.Helpers.Images;
using RentACar.Data.Repository.Abstracts;
using RentACar.Data.Repository.Concretes;
using RentACar.Data.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

   builder.Services.AddScoped<ICarService, CarService>();
   builder.Services.AddScoped<ICategoryService, CategoryService>();
   builder.Services.AddScoped<IBrandService, BrandService>();
   builder.Services.AddScoped<IImageHelper, ImageHelper>();
   builder.Services.AddScoped<IUserService, UserService>();
   builder.Services.AddScoped<IRentalService, RentalService>();
   builder.Services.AddScoped<ICommentService, CommentService>();
   builder.Services.AddScoped<IMailService, MailService>();
   builder.Services.AddScoped<RoleManager<AppRole>>();
   builder.Services.AddScoped<IPaymentService, PaymentService>();
   builder.Services.AddScoped<IPaymentOptionService, PaymentOptionService>();
    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(Startup));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser, AppRole>(opt => { //identity yapýlanmasý
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
}).AddErrorDescriber<CustomIdentityErrorDescriber>()
   .AddRoleManager<RoleManager<AppRole>>()
   .AddEntityFrameworkStores<AppDbContext>()
   .AddDefaultTokenProviders();
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddHostedService<RememberEmailService>();
builder.Services.AddHostedService<AutoDeletionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();