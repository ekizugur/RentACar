using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.Data.Context;
using RentACar.Data.DTOs.Cars;
using RentACar.Data.UnitOfWorks;
using RentACar.Entity.Entities;
using RentACar.Entity.Enums;
using RentACar.Service.Helpers.Images;
using RentACar.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace RentACar.Service.Services.Concretes
{
    public class CarService:ICarService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageHelper imageHelper;
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;
        private readonly UserManager<AppUser> userManager;
        private readonly IUserService userService;
        private readonly AppDbContext dbContext;

        public CarService(IUnitOfWork unitOfWork,IImageHelper imageHelper, IMapper mapper, IBrandService brandService, ICategoryService categoryService,UserManager<AppUser> userManager,IUserService userService,AppDbContext dbContext)
        {
            this.unitOfWork = unitOfWork;
            this.imageHelper = imageHelper;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.userManager = userManager;
            this.userService = userService;
            this.dbContext = dbContext;
        }

        public async Task AddCarAsync(CarAddDto carAddDto)
        {
            var userName=userService.GetUserName();
            var imageUpload = await imageHelper.Upload(carAddDto.Model,carAddDto.Photo,ImageType.Post); //new car oluştururken image id vermemiz gerektiği için oluşturmadan önce image ekliyoruz.
            Image image = new(imageUpload.FullName,carAddDto.Photo.ContentType,userName);
            await unitOfWork.GetRepository<Image>().AddAsync(image);

            var car = new Car
            {
                CreatedBy = userName,
                BrandId = carAddDto.BrandId,
                ImageId=image.Id,
                CategoryId= carAddDto.CategoryId,
                FuelType=carAddDto.FuelType,
                Kilometer = carAddDto.Kilometer,
                ProductionYear=carAddDto.ProductionYear,
                Price=carAddDto.Price,
                Model=carAddDto.Model,
                Description=carAddDto.Description
            };
            await unitOfWork.GetRepository<Car>().AddAsync(car);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<CarDto>> GetAllCarsCategoryNonDeleteAysnc()
        {
            var cars = await unitOfWork.GetRepository<Car>().GetAllAsync(x => !x.IsDeleted, x => x.Category, x=> x.Brand,x=>x.Image);
            var map=mapper.Map<List<CarDto>>(cars);
            return map.OrderByDescending(x=>x.CreatedDate).ToList();
        }
        public async Task<List<CarDto>> GetAllDeletedCarWithBrandAndCategory()
        {
            var cars=await unitOfWork.GetRepository<Car>().GetAllAsync(x=>x.IsDeleted,x=>x.Category, x=> x.Brand);
            var map = mapper.Map<List<CarDto>>(cars);
            return map;
        }

        public async Task SafeDeleteCarAsync(Guid carId)
        {
            var userName = userService.GetUserName();
            var car = await unitOfWork.GetRepository<Car>().GetByGuidAsync(carId);
            car.IsDeleted= true;
            car.IsDeletedBy = userName;
            car.DeletedTime= DateTime.Now;
            await unitOfWork.GetRepository<Car>().UpdateAsync(car);
            await unitOfWork.SaveAsync();
        }

        public async Task<CarDto> GetCarWithCategoryNonDeletedAsync(Guid carId)
        {
            var car = await unitOfWork.GetRepository<Car>().GetAsync(x => !x.IsDeleted && x.Id == carId, x => x.Category, x=>x.Brand, x => x.Image, x => x.Comments);
            var map=mapper.Map<CarDto>(car);
            return map;
        }
        public async Task UpdateCarAsync(CarUpdateDto carUpdateDto)
        {
            var userName = userService.GetUserName();
            var car = await unitOfWork.GetRepository<Car>().GetAsync(x => !x.IsDeleted && x.Id == carUpdateDto.Id, x => x.Category, x=>x.Brand,i=>i.Image);
            
            if (carUpdateDto.Photo != null)
            {
                imageHelper.Delete(car.Image.FileName);
                var imageUpload = await imageHelper.Upload(carUpdateDto.Model, carUpdateDto.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, carUpdateDto.Photo.ContentType, userName); 
                await unitOfWork.GetRepository<Image>().AddAsync(image);
                carUpdateDto.Image.Id = image.Id;
            }
            else
            {
                carUpdateDto.Image = car.Image;
            }

            var result = mapper.Map(carUpdateDto, car);

            car.UpdatedDate= DateTime.Now;
            car.UpdatedBy =userName;
            
            await unitOfWork.GetRepository<Car>().UpdateAsync(car);
            await unitOfWork.SaveAsync();


        }
        public async Task UpdateDeletedCarAsync(CarUpdateDto carUpdateDto)
        {
            var userName = userService.GetUserName();
            var car = await unitOfWork.GetRepository<Car>().GetAsync(x => x.IsDeleted && x.Id == carUpdateDto.Id, x => x.Category, x => x.Brand, i => i.Image);

            if (carUpdateDto.Photo != null)
            {
                imageHelper.Delete(car.Image.FileName);
                var imageUpload = await imageHelper.Upload(carUpdateDto.Model, carUpdateDto.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, carUpdateDto.Photo.ContentType, userName);
                await unitOfWork.GetRepository<Image>().AddAsync(image);
                carUpdateDto.Image.Id = image.Id;
            }
            else
            {
                carUpdateDto.Image = car.Image;
            }

            var result = mapper.Map(carUpdateDto, car);

            car.UpdatedDate = DateTime.Now;
            car.UpdatedBy = userName;

            await unitOfWork.GetRepository<Car>().UpdateAsync(car);
            await unitOfWork.SaveAsync();


        }
        public async Task<CarDto> GetCarWithCategoryAndBrandDeletedAsync(Guid carId)
        {
            var car = await unitOfWork.GetRepository<Car>().GetAsync(x => x.IsDeleted && x.Id == carId, x => x.Category, x => x.Brand, x => x.Image);
            var map = mapper.Map<CarDto>(car);
            return map;
        }
        public async Task PassiveToActiveCarAsync(Guid carId)
        {
            var userName = userService.GetUserName();
            var car = await unitOfWork.GetRepository<Car>().GetByGuidAsync(carId);
            car.IsDeleted = false;
            car.UpdatedDate=DateTime.Now;
            await unitOfWork.GetRepository<Car>().UpdateAsync(car);
            await unitOfWork.SaveAsync();
        }
        public async Task<List<CarDto>> SearchAsync(string searchString,Guid? categoryId,Guid? brandId,decimal minPrice,decimal maxPrice)
        {
            var cars = await unitOfWork.GetRepository<Car>().GetAllAsync(x => !x.IsDeleted,x=>x.Brand,x=>x.Category,x=>x.Image);

            //&& (x.Brand.Name.Contains(searchString) || x.Model.Contains(searchString) || x.Description.Contains(searchString))
            if (!string.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(x=>x.Brand.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) || 
                    x.Model.Contains(searchString, StringComparison.OrdinalIgnoreCase) || x.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (categoryId != null)
            {
                var capturedCategoryId = categoryId.Value;
                cars = cars.Where(x=>x.CategoryId == capturedCategoryId).ToList();
            }
            if(brandId != null)
            {
                var capturedBrandId = brandId.Value;
                cars = cars.Where(x=>x.BrandId == capturedBrandId).ToList();
            }
            if(minPrice!=0)
            {
                
                cars=cars.Where(x=>x.Price>=minPrice).ToList();
            }
            if(maxPrice!=0)
            {
                cars=cars.Where(x=>x.Price<=maxPrice).ToList();
            }
               
            
            var map=mapper.Map<List<CarDto>>(cars);
            return map;
        }
        

    }
}
