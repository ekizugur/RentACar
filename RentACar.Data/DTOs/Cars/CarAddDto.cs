using Microsoft.AspNetCore.Http;
using RentACar.Data.DTOs.Brand;
using RentACar.Data.DTOs.Categories;
using RentACar.Data.DTOs.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.DTOs.Cars
{
    public class CarAddDto
    {
        public IList<BrandDto> Brands { get; set; }
        public Guid BrandId { get; set; }
        public string Model { get; set; }
        public int Kilometer { get; set; }
        public int ProductionYear { get; set; }
        public string Description { get; set; }
        public string FuelType { get; set; }        
        public IFormFile Photo { get; set; }
        public IList<CategoryDto> Categories { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
