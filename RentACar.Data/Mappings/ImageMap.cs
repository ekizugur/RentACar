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
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(
                new Image
                {
                    Id = Guid.Parse("CFAFABCD-8C44-408B-90A4-D9D892007780"),
                    FileName = "images/testimage",
                    FileType="jpg",
                    CreatedBy="Admin Test",
                    CreatedDate=DateTimeOffset.Now.DateTime,
                    IsDeleted=false,
                    
                    

                },
                new Image
                {
                    Id = Guid.Parse("CE347EBF-815C-4A92-9BD4-12D5C50C378E"),
                    FileName = "images/vstest",
                    FileType = "png",
                    CreatedBy = "Admin Test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    
                }
                );
        }
    }
}
