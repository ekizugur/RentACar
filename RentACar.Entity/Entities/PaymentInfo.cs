using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entity.Entities
{
    public class PaymentInfo:EntityBase
    {
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public bool PaymentStatus { get; set; }
        public Guid UserId { get; set; }
    }
}
