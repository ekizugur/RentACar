using AutoMapper;
using RentACar.Data.DTOs.Payments;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.AutoMapper.Payments
{
    public class PaymentInfoProfile:Profile
    {
        public PaymentInfoProfile()
        {
            CreateMap<PaymentInfoDto,PaymentInfo>().ReverseMap();
            CreateMap<PaymentInfoAddDto,PaymentInfo>().ReverseMap();
        }
    }
}
