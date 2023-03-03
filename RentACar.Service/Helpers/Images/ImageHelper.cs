using Microsoft.AspNetCore.Hosting;
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
    public class ImageHelper : IImageHelper
    {
        
        private readonly string wwwroot;
        private readonly IWebHostEnvironment env;
        private const string imgFolder = "images";
        private const string carImagesFolder = "car-images";
        private const string userImagesFolder = "user-images";

        public ImageHelper(IWebHostEnvironment env)//webhostenv ile rootumuzu bulacağız
        {
            this.env = env;
            wwwroot = env.WebRootPath; //wwroot çağırdığında anadizindeki wwroot klasörüne gideceğini anlıyor
        }

        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }

        public async Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null)
        {
            //önce imagetype oluşturmamız gerekiyor. daha sonra imagetype dan sorgulama yapılacak imagetype car için  mi 
            folderName ??= imageType == ImageType.User ? userImagesFolder : carImagesFolder;
            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}"))
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");

            string oldFileName=Path.GetFileNameWithoutExtension(imageFile.FileName); //sadece resim adı
            string fileExtensions = Path.GetExtension(imageFile.FileName); //resmin uzantısını alıyor

            name = ReplaceInvalidChars(name); //yolladığımız name e yukarıdaki replace işlemini yaptırıp ismini değiştiriyoruz. Buradada aynı isimde çakışmaması için datettimedan gelen veri ile işlem yapacağıoz
            DateTime dateTime = DateTime.Now;
            //yeni isimlendirme formatı atıyoruz
            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtensions}";
            var path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}",newFileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync(); //using işlemi kullandığımız işin flushasync ile boşalttık

            string message = imageType == ImageType.User ? $"kullanıcı resmi başarı ile eklendi" : "Araç resmi başarıyla eklendi";

            return new ImageUploadedDto
            {
                FullName = $"{folderName}/{newFileName}"
            };
        }

        public void Delete(string ImageName)
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/{ImageName}");
            if(File.Exists(fileToDelete))
                File.Delete(fileToDelete);

        }
    }
}
