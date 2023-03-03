using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using RentACar.Data.DTOs.Brand;
using RentACar.Data.DTOs.Cars;
using RentACar.Data.DTOs.Categories;
using RentACar.Data.UnitOfWorks;
using RentACar.Entity.Entities;
using RentACar.Service.Services.Abstractions;
using RentACar.Service.Services.Concretes;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService brandService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;

        public BrandController(IBrandService brandService,IUnitOfWork unitOfWork,IUserService userService,IMapper mapper, IToastNotification toast)
        {
            this.brandService = brandService;
            this.unitOfWork = unitOfWork;
            this.userService = userService;
            this.mapper = mapper;
            this.toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            var brands = await brandService.GetAllBrandsNonDeleted();
            return View(brands);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(BrandAddDto brandAddDto)
        {
            var brand = await unitOfWork.GetRepository<Brand>().CountAsync(x=>!x.IsDeleted && x.Name == brandAddDto.Name);
            if(brand == 0)
            {
                await brandService.Add(brandAddDto);
                return RedirectToAction("Index", "Brand", new { Area = "Admin" });
            }
            else
            {                
                TempData["BrandError"] = $"{brandAddDto.Name} isimde marka zaten mevcut";
                return View();
            }



        }
        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] BrandAddDto brandAddDto)
        {
            var brand = await unitOfWork.GetRepository<Brand>().CountAsync(x => !x.IsDeleted && x.Name == brandAddDto.Name);
            if (brand == 0 && brandAddDto.Name != null)
            {
                await brandService.Add(brandAddDto);
                toast.AddSuccessToastMessage($"{brandAddDto.Name} başarıyla eklendi", new ToastrOptions { Title = "Başarılı" });
                return Json("Başarı ile eklendi");
            }
            else
            {
                toast.AddSuccessToastMessage($"{brandAddDto.Name} isminde kategori zaten mevcut", new ToastrOptions { Title = "Hata" });
                return Json("Hata");


            }

        }
        public async Task<IActionResult> SafeDelete(Guid brandId)
        {
            await brandService.SafeDelete(brandId);
            return RedirectToAction("Index", "Brand", new { Area = "Admin" });
        }
        public async Task<IActionResult> DeletedBrands()
        {
            var brands=await brandService.GetAllBrandsDeleted();
            return View(brands);
        }
        public async Task<IActionResult> PassiveToActive(Guid brandId)
        {
            await brandService.PassiveToActive(brandId);
            return RedirectToAction("Index", "Brand", new { Area = "Admin" });
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid brandId)
        {
            var brand = await brandService.GetBrandNonDeletedAsync(brandId);
            var brandUpdateDto = mapper.Map<BrandUpdateDto>(brand);
            return View(brandUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(BrandUpdateDto brandUpdateDto)
        {
            await brandService.Update(brandUpdateDto);
            return RedirectToAction("Index", "Brand", new { Area = "Admin" });
        }
    }
}
