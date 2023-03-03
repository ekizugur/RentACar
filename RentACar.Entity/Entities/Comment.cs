using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entity.Entities
{
    public class Comment:EntityBase
    {
        
        public AppUser User { get; set; }
        public Guid UserId { get; set; }
        public string CommentText { get; set; }
        public Car Car { get; set; }
        public Guid CarId { get; set; }
        public bool IsApproved { get; set; } = false;
    }
}
