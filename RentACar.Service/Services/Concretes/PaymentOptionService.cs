using Iyzipay;
using RentACar.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services.Concretes
{
    public class PaymentOptionService : IPaymentOptionService
    {
        private readonly Options _options;

        public PaymentOptionService()
        {
            _options = new Options
            {
                ApiKey = "sandbox-b94bTl4YdABmuxupHg8GqaalvjXcILsr",
                SecretKey = "sandbox-cOUS9viKInJsmK755ZvivZeeCDCnv87n",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };
        }

        public Options GetOptions()
        {
            return _options;
        }
    }
}
