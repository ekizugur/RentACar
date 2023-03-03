using RentACar.Core.Entities;
using RentACar.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entity.Entities
{
    public class Image:EntityBase
    {
        public Image() { }
        public Image(string fileName,string fileType,string createdBy)
        {
            FileName = fileName;
            FileType = fileType; 
            CreatedBy = createdBy;
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ImageType ImageType { get; set; }
        public ICollection<Car> Cars { get; set; }
        public AppUser Users { get; set;  }
        
    }
}
