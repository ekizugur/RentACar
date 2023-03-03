using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.DTOs.Comments
{
    public class CommentUpdateDto
    {
        public Guid Id { get; set; }
        public string CommentText { get; set; }
    }
}
