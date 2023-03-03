using AutoMapper;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using RentACar.Data.DTOs.Payments;
using RentACar.Data.UnitOfWorks;
using RentACar.Entity.Entities;
using RentACar.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services.Concretes
{
    public class PaymentService:IPaymentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PaymentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task addPayment(PaymentInfoDto paymentInfoDto)
        {
            var paymentInfo = new PaymentInfo
            {
                CreatedBy=paymentInfoDto.CreatedBy,
                CreatedDate=paymentInfoDto.CreatedDate,
                Id=paymentInfoDto.Id,
                PaymentAmount=paymentInfoDto.PaymentAmount,
                UserId=paymentInfoDto.UserId,
                PaymentDate=paymentInfoDto.PaymentDate,
                PaymentStatus=paymentInfoDto.PaymentStatus,
                
                        

            };
            await unitOfWork.GetRepository<PaymentInfo>().AddAsync(paymentInfo);
            await unitOfWork.SaveAsync();
        }
        public async Task<PaymentInfoDto> GetPaymentById(Guid paymentId)
        {
            var payment = await unitOfWork.GetRepository<PaymentInfo>().GetByGuidAsync(paymentId);
            var map=mapper.Map<PaymentInfoDto>(payment);
            return map;
        }
        

    }

}

