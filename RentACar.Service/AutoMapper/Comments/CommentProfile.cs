using AutoMapper;
using RentACar.Data.DTOs.Comments;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.AutoMapper.Comments
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentAddDto,Comment>().ReverseMap();
            CreateMap<CommentDto,Comment>().ReverseMap();
            CreateMap<CommentUpdateDto,Comment>().ReverseMap();
            CreateMap<CommentUpdateDto,CommentDto>().ReverseMap();
        }
    }
}
