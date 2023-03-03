using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data.DTOs.Comments;
using RentACar.Entity.Entities;
using RentACar.Service.Services.Abstractions;
using System.Data;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            this.commentService = commentService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid CarId)
        {
            var comments = await commentService.GetAllCommentByCarIdAsync(CarId);
            return View(comments);
        }
        public async Task<IActionResult> IsApproved(Guid commentId, Guid carId)
        {
            await commentService.IsApproved(commentId);
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> IsNotApproved(Guid commentId, Guid carId)
        {
            await commentService.IsNotApproved(commentId);
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> SafeDelete(Guid commentId)
        {
            try
            {
                await commentService.SafeDelete(commentId);
                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public async Task<IActionResult> DeleteToActive(Guid commentId)
        {
            try
            {
                await commentService.DeleteToActive(commentId);
                return Redirect(Request.Headers["Referer"].ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IActionResult> Update(Guid commentId)
        {
            if(commentId== Guid.Empty)
            {
                return NotFound();
            }
            var comment = await commentService.GetCommentById(commentId);
            if (comment == null)
            {
                // geçersiz bir yorum ID'si ile istek yapılmış
                return NotFound();
            }
            
            var commentUpdateDto = mapper.Map<CommentUpdateDto>(comment);
            return View(commentUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CommentUpdateDto commentUpdateDto)
        {
            await commentService.Update(commentUpdateDto);
            return View(commentUpdateDto);
        }
    }
}
