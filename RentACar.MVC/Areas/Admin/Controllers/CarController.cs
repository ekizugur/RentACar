using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data.DTOs.Cars;
using RentACar.Data.UnitOfWorks;
using RentACar.Entity.Entities;
using RentACar.Service.Extensions;
using RentACar.Service.Services.Abstractions;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IBrandService brandService;
        private readonly IValidator<Car> validator;

        public CarController(ICarService carService, ICategoryService categoryService, IMapper mapper, IBrandService brandService,IValidator<Car> validator)
        {
            this.carService = carService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.brandService = brandService;
            this.validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var cars = await carService.GetAllCarsCategoryNonDeleteAysnc();
            return View(cars);
        }
        public async Task<IActionResult> DeletedCar()
        {
            var cars=await carService.GetAllDeletedCarWithBrandAndCategory();
            return View(cars);
        }
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            var brands = await brandService.GetAllBrandsNonDeleted();
            return View(new CarAddDto { Categories = categories, Brands = brands });

        }
        [HttpPost]        
        public async Task<IActionResult> Add(CarAddDto carAddDto)
        {
            var map = mapper.Map<Car>(carAddDto);
            var result = await validator.ValidateAsync(map); //validation content istiyor fakat elimizde caradddto var map işlemi yapmamız gerekiyor.

            if (result.IsValid)
            {
                if (carAddDto.Photo != null) { 
                    await carService.AddCarAsync(carAddDto);
                return RedirectToAction("Index", "Car", new { Area = "Admin" });
                }
                else
                {
                    TempData["ImageError"] = "Lütfen resim ekleyiniz.";
                }
            }
            else 
            {
                result.AddToModalState(this.ModelState);
                
            }
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            var brands = await brandService.GetAllBrandsNonDeleted();
            return View(new CarAddDto { Categories = categories, Brands = brands });
        }
        public async Task<IActionResult> SafeDelete(Guid carId)
        {
            await carService.SafeDeleteCarAsync(carId);
            return RedirectToAction("Index", "Car", new { Area = "Admin" });
        }
        public async Task<IActionResult> PassiveToActive(Guid carId)
        {
            await carService.PassiveToActiveCarAsync(carId);
            return RedirectToAction("Index", "Car", new { Area = "Admin" });
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid carId)
        {
            var car = await carService.GetCarWithCategoryNonDeletedAsync(carId);
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            var brands = await brandService.GetAllBrandsNonDeleted();
            

            //boşta kalan alanlar olduğu için mapleyerek verirsek tüm verilere erişmiş oluruz.
            var carUpdateDto=mapper.Map<CarUpdateDto>(car);
            carUpdateDto.Categories = categories;
            carUpdateDto.Brands= brands;

            return View(carUpdateDto);
        }
        [HttpGet]
        public async Task<IActionResult> DeletedCarUpdate(Guid carId)
        {

            var car = await carService.GetCarWithCategoryAndBrandDeletedAsync(carId);
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            var brands = await brandService.GetAllBrandsNonDeleted();


            //boşta kalan alanlar olduğu için mapleyerek verirsek tüm verilere erişmiş oluruz.
            var carUpdateDto = mapper.Map<CarUpdateDto>(car);
            carUpdateDto.Categories = categories;
            carUpdateDto.Brands = brands;

            return View(carUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarUpdateDto carUpdateDto)
        {

            var map = mapper.Map<Car>(carUpdateDto);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await carService.UpdateCarAsync(carUpdateDto);
                return RedirectToAction("Index", "Car", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            var categories = await categoryService.GetAllCategoriesNonDeleted();
            carUpdateDto.Categories = categories;
            var brands= await brandService.GetAllBrandsNonDeleted();
            carUpdateDto.Brands= brands;
            return View(carUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> DeletedCarUpdate(CarUpdateDto carUpdateDto)
        {
            var map=mapper.Map<Car>(carUpdateDto);
            var result = await validator.ValidateAsync(map);
            if(result.IsValid)
            {
                await carService.UpdateDeletedCarAsync(carUpdateDto);
                return RedirectToAction("DeletedCar", "Car", new { Area = "Admin" });
            }
            else
            {
                result.AddToModalState(this.ModelState);
                var categories = await categoryService.GetAllCategoriesNonDeleted();
                carUpdateDto.Categories = categories;
                var brands = await brandService.GetAllBrandsNonDeleted();
                carUpdateDto.Brands = brands;
                return View(carUpdateDto);
            }
        }



        
    }
}
