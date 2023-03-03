using AutoMapper;
using RentACar.Data.DTOs.Brand;
using RentACar.Data.DTOs.Categories;
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
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public BrandService(IUnitOfWork unitOfWork,IMapper mapper,IUserService userService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userService = userService;
        }
        public async Task<List<BrandDto>> GetAllBrandsNonDeleted()
        {
            var brands=await unitOfWork.GetRepository<Brand>().GetAllAsync(x=>!x.IsDeleted);
            var map=mapper.Map<List<BrandDto>>(brands);
            return map;
        }
        public async Task<List<BrandDto>> GetAllBrandsDeleted()
        {
            var brands = await unitOfWork.GetRepository<Brand>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<BrandDto>>(brands);
            return map;
        }
        public async Task Add(BrandAddDto brandAddDto)
        {
            var userName = userService.GetUserName();

            var brand = new Brand
            {
                CreatedBy = userName,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Name = brandAddDto.Name,
            };
            
            await unitOfWork.GetRepository<Brand>().AddAsync(brand);
            await unitOfWork.SaveAsync();
        }
        public async Task<BrandDto> GetBrandNonDeletedAsync(Guid id)
        {
            var brand = await unitOfWork.GetRepository<Brand>().GetAsync(x => !x.IsDeleted && x.Id == id);
            var map = mapper.Map<BrandDto>(brand);
            return map;
        }
        public async Task SafeDelete(Guid Id)
        {
            var userName=userService.GetUserName();
            var brand= await unitOfWork.GetRepository<Brand>().GetByGuidAsync(Id);
            brand.IsDeleted=true;
            brand.DeletedTime = DateTime.Now;
            brand.IsDeletedBy = userName;
            await unitOfWork.GetRepository<Brand>().UpdateAsync(brand);
            await unitOfWork.SaveAsync();
        }
        public async Task PassiveToActive(Guid Id)
        {
            var userName = userService.GetUserName();
            var brand=await unitOfWork.GetRepository<Brand>().GetByGuidAsync(Id);
            brand.IsDeleted = false;
            brand.UpdatedBy= userName;
            brand.UpdatedDate= DateTime.Now;
            await unitOfWork.GetRepository<Brand>().UpdateAsync(brand);
            await unitOfWork.SaveAsync();
        }
        public async Task Update(BrandUpdateDto brandUpdateDto)
        {
            var userName = userService.GetUserName();
            var brand=await unitOfWork.GetRepository<Brand>().GetAsync(x=>!x.IsDeleted && x.Id==brandUpdateDto.Id);
            var result = mapper.Map(brandUpdateDto, brand);
            brand.UpdatedBy = userName;
            brand.UpdatedDate= DateTime.Now;
            brand.Name=brandUpdateDto.Name;

            
            await unitOfWork.GetRepository<Brand>().UpdateAsync(brand);
            await unitOfWork.SaveAsync();
        }
    }
}
