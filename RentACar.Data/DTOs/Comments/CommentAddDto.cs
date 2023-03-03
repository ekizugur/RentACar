using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.DTOs.Comments
{
    public class CommentAddDto
    {
        public string CommentText { get; set; }
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

    }
}
