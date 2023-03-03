using RentACar.Data.DTOs.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services.Abstractions
{
    public interface IPaymentService
    {
        Task addPayment(PaymentInfoDto paymentInfoDto);
        Task<PaymentInfoDto> GetPaymentById(Guid paymentId);
    }
}
