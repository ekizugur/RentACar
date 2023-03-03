using RentACar.Data.DTOs.Brand;
using RentACar.Data.DTOs.Categories;
using RentACar.Data.DTOs.Comments;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.DTOs.Cars
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public BrandDto Brand { get; set; }   
        public Guid BrandId { get; set; }
        public Image Image { get; set; }
        public string Model { get; set; }
        public int Kilometer { get; set; }
        public string Description { get; set; }
        public int RentCount { get; set; }
        public int ProductionYear { get; set; }
        public string FuelType { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        public CategoryDto Category { get; set; }
        public Guid CategoryId { get; set; }
        public string IsDeletedBy { get; set; }
        public decimal Price { get; set; }
        public IList<CommentDto> Comments { get; set; }




    }
}
