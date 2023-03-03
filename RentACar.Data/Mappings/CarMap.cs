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
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(new Car
            {
                Id=Guid.NewGuid(),
                BrandId=Guid.Parse("76F3368D-44F7-4377-BA91-B394B00737D4"),
                Model="E250",
                Kilometer=50545,
                RentCount=10,
                CategoryId=Guid.Parse("EEABEC77-1EF1-46E1-A5E9-3B0CEFFBB6A4"),
                CreatedBy="Admin Test",
                CreatedDate=DateTimeOffset.Now.DateTime,
                Description= "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                IsDeleted=false,                
                FuelType="Dizel",
                ProductionYear=2015,                
                Price=600
            },
            new Car
            {
                Id = Guid.NewGuid(),
                BrandId= Guid.Parse("E37EB9B9-181B-4CA4-AD97-646F2B9D338B"),
                Model = "A3",
                Kilometer = 62511,
                RentCount = 3,
                CategoryId = Guid.Parse("8D0E6F75-280C-4B1B-A703-336AE28020EF"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTimeOffset.Now.DateTime,
                Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                IsDeleted = false,
                FuelType = "Benzin",
                ProductionYear = 2018,
                Price=850
            });
        }
    }
}
