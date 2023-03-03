using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.Mappings
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(new Brand
            {
                Name = "Mercedes",
                Id=Guid.Parse("76F3368D-44F7-4377-BA91-B394B00737D4"),
                CreatedBy="Admin Deneme",
                CreatedDate= DateTime.Now,
                IsDeleted=false,
                
                
            }
            ,new Brand
            {
                Name="Audi",
                Id=Guid.Parse("E37EB9B9-181B-4CA4-AD97-646F2B9D338B"),
                CreatedBy = "Admin Deneme",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
        }
    }
}
