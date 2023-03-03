using RentACar.Data.DTOs.Brand;
using RentACar.Data.DTOs.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace RentACar.Service.Services.Abstractions
{
    public interface ICommentService
    {
        Task AddComment(CommentAddDto commentAddDto);
        Task<List<CommentDto>> GetCommentsByCarIdAsync(Guid carId);
        Task<List<CommentDto>> GetAllCommentByCarIdAsync(Guid carId);
        Task IsApproved(Guid commentId);
        Task IsNotApproved(Guid commentId);
        Task SafeDelete(Guid commentId);
        Task DeleteToActive(Guid commentId);
        Task<CommentDto> GetCommentById(Guid commentId);
        Task Update(CommentUpdateDto commentUpdateDto);
    }
}
