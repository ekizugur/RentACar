using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using RentACar.Data.DTOs;
using RentACar.Data.DTOs.Cars;
using RentACar.Data.UnitOfWorks;
using RentACar.Entity.Entities;
using RentACar.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services.Concretes
{
    public class RentalService:IRentalService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly ICarService carService;
        private readonly IMailService mailService;
        private readonly IConfiguration config;

        public RentalService(IUnitOfWork unitOfWork,IUserService userService,IMapper mapper,ICarService carService,IMailService mailService, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.userService = userService;
            this.mapper = mapper;
            this.carService = carService;
            this.mailService = mailService;
            this.config = config;
        }

        public async Task Rent(CarRentalDto carRentalDto)
        {
            var car = await unitOfWork.GetRepository<Car>().GetAsync(x => x.Id == carRentalDto.CarId, x => x.Brand, x => x.Image, x => x.Category);
            try
            {
                var existingRental = await unitOfWork.GetRepository<Rental>().CountAsync(x =>
                 x.CarId == carRentalDto.CarId &&
                 x.IsActive == true &&
                 (x.RentDate <= carRentalDto.ReturnDate && x.ReturnDate >= carRentalDto.RentDate && x.IsActive==true));
                if (existingRental != 0)
                {
                    throw new Exception("Bu araç seçtiğiniz tarihler arasında kiralanmıştır. Lütfen tarih aralığını değiştirin veya diğer araçlarımıza göz atın.");
                }
                var userName = userService.GetUserName();
                var userId = userService.GetUserId();
                var rent = new Rental
                {
                    CarId = carRentalDto.CarId,
                    CreatedBy = userName,
                    UserId = carRentalDto.UserId,
                    CreatedDate = DateTimeOffset.Now,
                    IsActive = true,
                    PaymentId= carRentalDto.PaymentId,
                    PaymentInfoId=carRentalDto.PaymentInfoId,
                    RentDate = carRentalDto.RentDate,
                    ReturnDate = carRentalDto.ReturnDate,
                    TransactionId=carRentalDto.TransactionId,
                    Id = Guid.NewGuid(),
                };
                await unitOfWork.GetRepository<Rental>().AddAsync(rent);
                car.RentCount += 1;
                await mailService.SendMessageAsync(rent.CreatedBy, "Araç Kiralama Bilgileri", $"{DateTime.Now} tarihinde gerçekleştirmiş olduğunuz araç kiralama bilgileriniz şu şekildedir: <br>" +
                    $"{car.Brand.Name} {car.Model} markalı araç <br> Araç Kiralama başlangıç tarihi: {rent.RentDate} Araç Teslim Tarihi: {rent.ReturnDate} şeklindedir.");
                await unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<Car> GetCarById(Guid carId)
        {
            return await unitOfWork.GetRepository<Car>().GetAsync(x=>x.Id== carId, x=>x.Brand,x=>x.Image,x=>x.Category);
        }
        public async Task<bool> isAvailable(Guid carId, DateTime RentACar,DateTime EndTime)
        {

            var car=await unitOfWork.GetRepository<Car>().GetByGuidAsync(carId);
            try
            {
                var existingRental = await unitOfWork.GetRepository<Rental>().CountAsync(x =>
                 x.CarId == carId &&
                 x.IsActive == true &&
                 (x.RentDate <= EndTime && x.ReturnDate >= RentACar));
                if (existingRental != 0)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<CarRentalDto>> GetAllRentalsAsync()
        {
            var rentals=await unitOfWork.GetRepository<Rental>().GetAllAsync(x=>!x.IsDeleted, x=>x.Car, X=>X.User);
            var map=mapper.Map<List<CarRentalDto>>(rentals);
            return map;
        }
        public async Task<List<CarRentalDto>> GetRefundRequestsAsync()
        {
            var rentals = await unitOfWork.GetRepository<Rental>().GetAllAsync(x => x.RefundRequest && x.IsActive, x => x.Car.Brand, x => x.Car, x => x.PaymentInfo,x=>x.User);
            var map = mapper.Map<List<CarRentalDto>>(rentals);
            return map;
        }

        public async Task<List<CarRentalDto>> GetRentalsByUserId(Guid userId)
        {
            var userRentals = await unitOfWork.GetRepository<Rental>().GetAllAsync(x => x.UserId == userId && !x.IsDeleted && x.IsActive, x => x.Car.Brand, x => x.Car, x => x.PaymentInfo);
            var map = mapper.Map<List<CarRentalDto>>(userRentals);
            return map;

        }
        public async Task<bool> RentalCancellation(Guid id)
        {
            var rental=await unitOfWork.GetRepository<Rental>().GetByGuidAsync(id);
            if(rental.IsActive==true)
            {
                rental.IsActive= false;
                await unitOfWork.GetRepository<Rental>().UpdateAsync(rental);
                await unitOfWork.SaveAsync();
                await mailService.SendMessageAsync(rental.CreatedBy, "Araç Kiralama İptal Bilgisi", $"{rental.RentDate} tarihinde başlayacak olan araç kiralama işleminiz iptal edilmiş olup ücret iadesi kartınıza yansıtılmıştır.");
                return true;
            }
            return false;
            
        }

        
        public async Task<CarRentalDto> RentalCancellationRequest(Guid id)
        {
            var rental = await unitOfWork.GetRepository<Rental>().GetAsync(x =>x.Id==id &&  x.IsActive && !x.RefundRequest);
            if(rental != null)
            {
                rental.RefundRequest = true;
                var map=mapper.Map<CarRentalDto>(rental);
                await unitOfWork.GetRepository<Rental>().UpdateAsync(rental);
                await unitOfWork.SaveAsync();
                return map;
            }
            else
            {
                throw new Exception();
            }
        }
        public async Task RentalControl()
        {
            var rentals = await unitOfWork.GetRepository<Rental>().GetAllAsync();
            foreach (var rental in rentals)
            {
                if(rental.ReturnDate < DateTime.Now)
                {
                    rental.IsActive = false;
                    
                    
                }
            }
            await unitOfWork.SaveAsync();
            
        }
        public async Task RentalRememberEmail()
        {
            try
            {
                var rentals = await unitOfWork.GetRepository<Rental>().GetAllAsync(x => x.IsActive && x.RentDate > DateTime.Now, x => x.Car.Brand, x => x.Car);
                foreach (var rental in rentals)
                {
                    DateTime rentDate = rental.RentDate;
                    TimeSpan difference = rentDate - DateTime.Now;
                    double days = difference.TotalDays;
                    if (days < 1 && days > 0)
                    {
                        await mailService.SendMessageAsync(rental.CreatedBy, "Araç Kiralama Hatırlatma",
                            $"{rental.Car.Brand.Name} {rental.Car.Model} " +
                            $"aracı kiralama işleminiz {rental.RentDate} Tarihinde başlayıp {rental.ReturnDate} tarihinde sonlanacaktır. Bu bir hatırlatma mailidir.");
                    }
                    else
                    {
                        Console.Write("hata");
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }
        }

       
    }

