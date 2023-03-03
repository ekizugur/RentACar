using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entity.Entities
{
    public class Car:EntityBase
    {
        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }
        public string Model { get; set; }
        public int Kilometer { get; set; }
        public int ProductionYear { get; set; }
        public string FuelType { get; set; }
        public string Description { get; set; }
        public int RentCount { get; set; } = 0;
        public Guid CategoryId { get; set; }

        public Image Image { get; set; }
        public Guid? ImageId { get; set; }

        public Category Category { get; set; }
        public decimal Price { get; set; }
        public IList<Comment>? Comments { get; set; }

    }
}
