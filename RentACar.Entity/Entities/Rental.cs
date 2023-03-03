using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entity.Entities
{
    public class Rental:EntityBase
    {
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public Car Car { get; set; }
        public bool IsActive { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string PaymentId { get; set; }
        public Guid PaymentInfoId { get; set; }
        public string TransactionId { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public bool RefundRequest { get; set; }=false;
    }
}
