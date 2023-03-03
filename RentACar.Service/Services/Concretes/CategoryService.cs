using AutoMapper;
using RentACar.Data.DTOs.Cars;
using RentACar.Data.DTOs.Categories;
using RentACar.Data.UnitOfWorks;
using RentACar.Entity.Entities;
using RentACar.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services.Concretes
{
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper,IUserService userService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userService = userService;
        }

        public async Task AddCategory(CategoryAddDto categoryAddDto)
        {
            var userName = userService.GetUserName();
            var category = new Category
            {
                CategoryName = categoryAddDto.CategoryName,
                CreatedBy=userName,
                CreatedDate=DateTime.Now,
                
            };
            await unitOfWork.GetRepository<Category>().AddAsync(category);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {
            var categories=await unitOfWork.GetRepository<Category>().GetAllAsync(k=>!k.IsDeleted);
            var map=mapper.Map<List<CategoryDto>>(categories);
            return map;
        }
        public async Task<CategoryDto> GetCategoryNonDeletedAsync(Guid id)
        {
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x=>!x.IsDeleted && x.Id==id);
            var map = mapper.Map<CategoryDto>(category);
            return map;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesDeleted()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(k => k.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);
            return map;
        }
        public async Task UpdateNonDeletedCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var userName = userService.GetUserName();
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == categoryUpdateDto.Id);

            var result = mapper.Map(categoryUpdateDto, category);
            category.UpdatedDate = DateTimeOffset.Now.DateTime;
            category.UpdatedBy = userName;

            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();
        }
        public async Task SafeDelete(Guid categoryId)
        {
            var userName = userService.GetUserName();
            var car = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            car.IsDeleted = true;
            car.DeletedTime = DateTime.Now;
            car.IsDeletedBy = userName;
            await unitOfWork.GetRepository<Category>().UpdateAsync(car);
            await unitOfWork.SaveAsync();
        }
        public async Task PassiveToActiveCategoryAsync(Guid categoryId)
        {
            var userName = userService.GetUserName();
            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = false;
            category.UpdatedDate = DateTime.Now;
            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();
        }

       
    }
}
