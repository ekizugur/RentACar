using AutoMapper;
using RentACar.Data.DTOs.Brand;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.AutoMapper.Brands
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandDto, Brand>().ReverseMap();
            CreateMap<BrandAddDto, Brand>().ReverseMap();
            CreateMap<BrandUpdateDto, Brand>().ReverseMap();
            CreateMap<BrandUpdateDto,BrandDto>().ReverseMap();
        }
    }
}
