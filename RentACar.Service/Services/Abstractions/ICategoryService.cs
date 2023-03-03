using RentACar.Data.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
        Task AddCategory(CategoryAddDto categoryAddDto);
        Task<CategoryDto> GetCategoryNonDeletedAsync(Guid id);
        Task UpdateNonDeletedCategoryAsync(CategoryUpdateDto categoryUpdateDto);
        Task<List<CategoryDto>> GetAllCategoriesDeleted();
        Task SafeDelete(Guid categoryId);
        Task PassiveToActiveCategoryAsync(Guid categoryId);

    }
}
