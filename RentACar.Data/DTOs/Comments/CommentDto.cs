using RentACar.Data.DTOs.Cars;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentACar.Data.DTOs.Comments
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string CommentText { get; set; }
        public Guid CarId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string IsDeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsApproved { get; set; }

    }
}

