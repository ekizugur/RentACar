using RentACar.Data.DTOs.Cars;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.DTOs.Brand
{
    public class BrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string IsDeletedBy { get; set; }

    }
}
