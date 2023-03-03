using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using RentACar.Data.DTOs.Brand;
using RentACar.Data.DTOs.Categories;
using RentACar.Data.UnitOfWorks;
using RentACar.Entity.Entities;
using RentACar.Service.Services.Abstractions;

namespace RentACar.MVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;

        public CategoryController(ICategoryService categoryService, IUnitOfWork unitOfWork,IMapper mapper, IToastNotification toast)
        {
            this.categoryService = categoryService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            var categories=await categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }

        public async Task<IActionResult> AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddDto categoryAddDto)
        {
            var category=await unitOfWork.GetRepository<Category>().CountAsync(x => !x.IsDeleted && x.CategoryName == categoryAddDto.CategoryName);
            if (category == 0) 
            { 
                await categoryService.AddCategory(categoryAddDto);
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            else
            {
                TempData["CategoryError"] = $"{categoryAddDto.CategoryName} isimde marka zaten mevcut";
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDto categoryAddDto)
        {
            var category = await unitOfWork.GetRepository<Category>().CountAsync(x => !x.IsDeleted && x.CategoryName == categoryAddDto.CategoryName);
            if (category == 0 && categoryAddDto.CategoryName!=null)
            {
                await categoryService.AddCategory(categoryAddDto);
                toast.AddSuccessToastMessage($"{categoryAddDto.CategoryName} başarıyla eklendi", new ToastrOptions { Title = "Başarılı" });
                return Json("Başarı ile eklendi");
            }
            else
            {
                toast.AddSuccessToastMessage($"{categoryAddDto.CategoryName} isminde kategori zaten mevcut", new ToastrOptions { Title = "Hata" });
                return Json("Hata");


            }

        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(Guid categoryId)
        {
            var category = await categoryService.GetCategoryNonDeletedAsync(categoryId);
            var categoryUpdateDto=mapper.Map<CategoryUpdateDto>(category);
            return View(categoryUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
            await categoryService.UpdateNonDeletedCategoryAsync(categoryUpdateDto);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        [HttpGet]
        public async Task<IActionResult> DeletedCategories()
        {
            var categories = await categoryService.GetAllCategoriesDeleted();
            return View(categories);
        }
        public async Task<IActionResult> SafeDelete(Guid categoryId)
        {
            await categoryService.SafeDelete(categoryId);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        public async Task<IActionResult> PassiveToActive(Guid categoryId)
        {
            await categoryService.PassiveToActiveCategoryAsync(categoryId);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }


    }
}
