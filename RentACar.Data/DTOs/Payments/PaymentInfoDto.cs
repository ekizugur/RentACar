using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.DTOs.Payments
{
    public class PaymentInfoDto
    {
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool PaymentStatus { get; set; }
        public Guid UserId { get; set; }
        public string PaymentId { get; set; }
    }
}
