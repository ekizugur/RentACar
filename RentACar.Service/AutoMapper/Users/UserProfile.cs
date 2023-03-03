using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RentACar.Data.DTOs.Users;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.AutoMapper.Users
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserLoginDto,AppUser>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<UserUpdateDto, UserDto>().ReverseMap();
            CreateMap<UserUpdateDto, AppUser>().ReverseMap();
        }
    }
}
