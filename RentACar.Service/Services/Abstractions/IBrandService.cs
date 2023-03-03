using RentACar.Data.DTOs.Brand;
using RentACar.Data.DTOs.Cars;
using RentACar.Data.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services.Abstractions
{
    public interface IBrandService
    {
        Task<List<BrandDto>> GetAllBrandsNonDeleted();
        Task Add(BrandAddDto brandAddDto);
        Task SafeDelete(Guid Id);
        Task<List<BrandDto>> GetAllBrandsDeleted();
        Task PassiveToActive(Guid Id);
        Task Update(BrandUpdateDto brandUpdateDto);
        Task<BrandDto> GetBrandNonDeletedAsync(Guid id);
        
    }
}
