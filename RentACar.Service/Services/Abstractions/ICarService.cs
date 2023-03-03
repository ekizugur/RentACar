using RentACar.Data.DTOs.Cars;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services.Abstractions
{
    public interface ICarService
    {
        Task<List<CarDto>> GetAllCarsCategoryNonDeleteAysnc();
        Task AddCarAsync(CarAddDto carAddDto);
        Task SafeDeleteCarAsync(Guid carId);
        Task UpdateCarAsync(CarUpdateDto carUpdateDto);
        Task<CarDto> GetCarWithCategoryNonDeletedAsync(Guid carId);
        Task<List<CarDto>> GetAllDeletedCarWithBrandAndCategory();
        Task UpdateDeletedCarAsync(CarUpdateDto carUpdateDto);
        Task<CarDto> GetCarWithCategoryAndBrandDeletedAsync(Guid carId);
        Task PassiveToActiveCarAsync(Guid carId);
        Task<List<CarDto>> SearchAsync(string searchString, Guid? categoryId, Guid? brandId, decimal minPrice, decimal maxPrice);
    }
}
