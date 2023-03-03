using AutoMapper;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data.DTOs.Cars;
using RentACar.Data.UnitOfWorks;
using RentACar.MVC.Models;
using RentACar.Service.Services.Abstractions;
using System.Diagnostics;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace RentACar.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService carService;
        private readonly ICategoryService categoryService;
        private readonly IMapper map;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger,ICarService carService,ICategoryService categoryService,IMapper map,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.carService = carService;
            this.categoryService = categoryService;
            this.map = map;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var cars = await carService.GetAllCarsCategoryNonDeleteAysnc();
            var pagedCars = cars.ToPagedList(page, 6); // ToPagedList() extension methodunu kullanarak veriyi sayfalamak için bir IPagedList nesnesi oluşturuyoruz.
            
            return View(pagedCars);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}