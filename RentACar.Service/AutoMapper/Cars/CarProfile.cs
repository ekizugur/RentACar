using AutoMapper;
using RentACar.Data.DTOs.Cars;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.AutoMapper.Cars
{
    public class CarProfile:Profile
    {
        public CarProfile() 
        {
            CreateMap<CarDto, Car>().ReverseMap();
            CreateMap<CarUpdateDto, Car>().ReverseMap();
            CreateMap<CarUpdateDto, CarDto>().ReverseMap();
            CreateMap<CarAddDto, Car>().ReverseMap();
            
        }
    }
}
