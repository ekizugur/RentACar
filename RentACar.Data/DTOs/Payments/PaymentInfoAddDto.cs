using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.DTOs.Payments
{
    public class PaymentInfoAddDto
    {
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public bool PaymentStatus { get; set; }
        public Guid UserId { get; set; }
    }
}
