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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id=Guid.Parse("8D0E6F75-280C-4B1B-A703-336AE28020EF"),
                CreatedBy="Admin Test",
                CreatedDate=DateTimeOffset.Now.DateTime,
                IsDeleted=false,
                CategoryName="Spor"
                
            }, new Category
            {
                Id=Guid.Parse("EEABEC77-1EF1-46E1-A5E9-3B0CEFFBB6A4"),
                CreatedBy="Admin Test",
                CreatedDate=DateTimeOffset.Now.DateTime,
                IsDeleted=false,
                CategoryName="Sedan",
                
            }
            
            
            );
        }
    }
}
