using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RentACar.Data.DTOs.Users;
using RentACar.Data.UnitOfWorks;
using RentACar.Entity.Entities;
using RentACar.Entity.Enums;
using RentACar.Service.Helpers.Images;
using RentACar.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<AppUser> userManager;

        public UserService(IHttpContextAccessor httpContextAccessor,IImageHelper imageHelper,IUnitOfWork unitOfWork,UserManager<AppUser> userManager)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.imageHelper = imageHelper;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public string GetUserId()
        {
            return httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string GetUserName()
        {
            return httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }

        public bool IsAuthenticated()
        {
            return httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public async Task ProfileUpdateAsync(UserDto userDto)
        {
            var userName = GetUserName();
            var user = await userManager.FindByNameAsync(userName);
            if (user != null)
            {
                var oldImageId = user.ImageId;
                if (userDto.Photo != null)
                {
                    var imageUpload = await imageHelper.Upload(userName, userDto.Photo, ImageType.User);
                    Image image = new(imageUpload.FullName, userDto.Photo.ContentType, userName);
                    await unitOfWork.GetRepository<Image>().AddAsync(image);

                    user.ImageId = image.Id;
                    if (oldImageId.HasValue)
                    {
                        var oldImage = await unitOfWork.GetRepository<Image>().GetByGuidAsync(oldImageId.Value);
                        imageHelper.Delete(oldImage.FileName);
                        await unitOfWork.GetRepository<Image>().DeleteAsync(oldImage);
                    }
                }
                await unitOfWork.SaveAsync();
            }
        }
    }
}
