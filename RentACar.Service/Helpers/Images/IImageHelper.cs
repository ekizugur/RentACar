using Microsoft.AspNetCore.Http;
using RentACar.Data.DTOs.Images;
using RentACar.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadedDto> Upload(string name, IFormFile imageFile,ImageType imageType,string folderName=null);
        void Delete(string ImageName);
    }
}
