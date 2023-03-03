using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data.DTOs;
using RentACar.Data.DTOs.Cars;
using RentACar.Data.UnitOfWorks;
using RentACar.Entity.Entities;
using RentACar.Service.Services.Abstractions;
using RentACar.Service.Services.Concretes;
using X.PagedList.Mvc.Core;
using X.PagedList;
using RentACar.Data.DTOs.Comments;
using System.Drawing.Printing;
using RentACar.MVC.Models;
using RentACar.Data.DTOs.Users;
using Microsoft.AspNetCore.Identity;

namespace RentACar.MVC.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly UserManager<AppUser> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IRentalService rentalService;
        private readonly ICommentService commentService;
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;

        public CarController(ICarService carService,UserManager<AppUser> userManager,IUnitOfWork unitOfWork,IUserService userService,IMapper mapper,IRentalService rentalService,ICommentService commentService,ICategoryService categoryService,IBrandService brandService) 
        {
            this.carService = carService;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.userService = userService;
            this.mapper = mapper;
            this.rentalService = rentalService;
            this.commentService = commentService;
            this.categoryService = categoryService;
            this.brandService = brandService;
        }
       
        public async Task<IActionResult> Detail(Guid carId, int page = 1)
        {
            var car = await carService.GetCarWithCategoryNonDeletedAsync(carId);
            var carDto = mapper.Map<CarDto>(car);
            
            var comments = await commentService.GetCommentsByCarIdAsync(carId);    
            int pageSize = 3;
            int pageNumber = page;
            var pagedComments = comments.ToPagedList(pageNumber, pageSize);

            var viewModel = new CarDetailViewModel
            {
                Car = carDto,
                Comments = pagedComments,
            };

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page=1)
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            ViewBag.Categories = categories;
            var brands=await brandService.GetAllBrandsNonDeleted();
            ViewBag.Brands = brands;
            var cars = await carService.GetAllCarsCategoryNonDeleteAysnc();
            var pagedCars = cars.ToPagedList(page, 6); // ToPagedList() extension methodunu kullanarak veriyi sayfalamak için bir IPagedList nesnesi oluşturuyoruz.
            return View(pagedCars);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string searchString, int page = 1,Guid? categoryId=null,Guid? brandId=null,decimal minPrice=0,decimal maxPrice=0)
        {
            var cars = await carService.SearchAsync(searchString,categoryId,brandId,minPrice,maxPrice);
            var pagedCars = cars.ToPagedList(page, 6); // ToPagedList() extension methodunu kullanarak veriyi sayfalamak için bir IPagedList nesnesi oluşturuyoruz.
            return View(pagedCars);
        }



    }
}
