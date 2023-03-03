using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RentACar.Data.DTOs.Comments;
using RentACar.Entity.Entities;
using RentACar.Service.Services.Abstractions;
using System.Data;

namespace RentACar.MVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICarService carService;
        private readonly IUserService userService;
        private readonly ICommentService commentService;

        public CommentController(ICarService carService, IUserService userService, ICommentService commentService)
        {
            this.carService = carService;
            this.userService = userService;
            this.commentService = commentService;
        }
        [HttpPost]
        
        public async Task<IActionResult> AddComment(CommentAddDto commentAddDto)
        {
            if (User.Identity.IsAuthenticated) 
            { 
            await commentService.AddComment(commentAddDto);
            TempData["CommentSuccess"] = "Yorumunuz başarıyla alındı ve yönetici onayına sunuldu.";
            return RedirectToAction("Detail", "Car", new {carId=commentAddDto.CarId, Area = "" });
            }
            TempData["RentError"] = "Yorum yapabilmek için kullanıcı girişi yapmalısınız!";
            return RedirectToAction("Detail", "Car", new {carId=commentAddDto.CarId, Area = "" });
        }

    }
}
