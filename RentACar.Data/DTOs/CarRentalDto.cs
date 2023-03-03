using RentACar.Data.DTOs.Cars;
using RentACar.Data.DTOs.Payments;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.DTOs
{
    public class CarRentalDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string PaymentId { get; set; }
        public Guid PaymentInfoId { get; set; }
        public string TransactionId { get; set; }
        public PaymentInfoDto PaymentInfo { get; set; }
        public bool RefundRequest{ get; set; }

    }
}
