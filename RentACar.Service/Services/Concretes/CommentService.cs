using AutoMapper;
using Microsoft.Identity.Client;
using RentACar.Data.DTOs.Brand;
using RentACar.Data.DTOs.Comments;
using RentACar.Data.UnitOfWorks;
using RentACar.Entity.Entities;
using RentACar.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Mvc.Core;


namespace RentACar.Service.Services.Concretes
{
    public class CommentService:ICommentService
    {
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CommentService(IUserService userService,IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.userService = userService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
       
        
        public async Task AddComment(CommentAddDto commentAddDto)
        {
            
            var userName=userService.GetUserName();
            var userId=userService.GetUserId();
            var comment = new Comment
            {
                CommentText = commentAddDto.CommentText,
                UserId = Guid.Parse(userId),
                CreatedDate = DateTime.Now,
                Id = new Guid(),
                CreatedBy = userName,
                IsApproved=false,
                CarId = commentAddDto.CarId,
            };
            await unitOfWork.GetRepository<Comment>().AddAsync(comment);
            await unitOfWork.SaveAsync();

        }
        public async Task<List<CommentDto>> GetCommentsByCarIdAsync(Guid carId)
        {
            var comments = await unitOfWork.GetRepository<Comment>().GetAllAsync(x=>x.CarId==carId && x.IsApproved==true && x.IsDeleted==false, x=>x.User.Image);
            var commentDtos = mapper.Map<List<CommentDto>>(comments);
            return commentDtos.OrderByDescending(x => x.CreatedDate).ToList();
            
        }
        public async Task<List<CommentDto>> GetAllCommentByCarIdAsync(Guid carId)
        {
            var comments=await unitOfWork.GetRepository<Comment>().GetAllAsync(x=>x.CarId== carId);
            var commentDtos=mapper.Map<List<CommentDto>>(comments);
            return commentDtos.OrderByDescending(_ => _.CreatedDate).ToList();
        }
        public async Task IsApproved(Guid commentId)
        {
            var userName = userService.GetUserName();
            var comment = await unitOfWork.GetRepository<Comment>().GetByGuidAsync(commentId);
            comment.IsApproved = true;
            comment.UpdatedDate = DateTime.Now;
            comment.UpdatedBy = userName;
            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();
        }
        public async Task IsNotApproved(Guid commentId)
        {
            var userName =userService.GetUserName();
            var comment = await unitOfWork.GetRepository<Comment>().GetByGuidAsync(commentId);
            comment.IsApproved = false;
            comment.UpdatedDate= DateTime.Now;
            comment.UpdatedBy = userName;
            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();
        }

        public async Task SafeDelete(Guid commentId)
        {
            try
            {
                var userName = userService.GetUserName();
                var comment = await unitOfWork.GetRepository<Comment>().GetByGuidAsync(commentId);
                comment.IsDeleted = true;
                comment.IsApproved= false;
                comment.IsDeletedBy = userName;
                comment.DeletedTime = DateTime.Now.Date;
                await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
                await unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        public async Task DeleteToActive(Guid commentId)
        {
            try
            {
                var userName=userService.GetUserName();
                var comment = await unitOfWork.GetRepository<Comment>().GetByGuidAsync(commentId);
                comment.IsDeleted = false;
                comment.IsApproved= true;
                comment.UpdatedDate= DateTime.Now;
                await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
                await unitOfWork.SaveAsync();
            }
            catch(Exception ex) { throw new Exception(ex.Message,ex); }
        }
        public async Task<CommentDto> GetCommentById(Guid commentId)
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetByGuidAsync(commentId);
            var map = mapper.Map<CommentDto>(comment);
            return map;
        }
        public async Task Update(CommentUpdateDto commentUpdateDto)
        {
            var userName = userService.GetUserName();
            var comment = await unitOfWork.GetRepository<Comment>().GetAsync(x=>x.Id==commentUpdateDto.Id);
            var result = mapper.Map(commentUpdateDto, comment);
            comment.UpdatedDate = DateTime.Now.Date;
            comment.UpdatedBy= userName;
            comment.CommentText= commentUpdateDto.CommentText;

            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();

        }
    }
}
