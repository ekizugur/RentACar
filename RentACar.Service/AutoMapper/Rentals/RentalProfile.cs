using AutoMapper;
using RentACar.Data.DTOs;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.AutoMapper.Rentals
{
    public class RentalProfile:Profile
    {
        public RentalProfile()
        {
            CreateMap<CarRentalDto, Rental>().ReverseMap()           
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
           .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
           .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
           //.ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
           .ForMember(dest => dest.RentDate, opt => opt.MapFrom(src => src.RentDate))
           .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate));
        }
    }
}
