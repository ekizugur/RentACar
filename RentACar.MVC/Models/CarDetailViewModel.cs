using RentACar.Data.DTOs.Cars;
using RentACar.Data.DTOs.Comments;
using RentACar.Data.DTOs.Users;
using X.PagedList;

namespace RentACar.MVC.Models
{
    public class CarDetailViewModel
    {
        public CarDto Car { get; set; }
        public IPagedList<CommentDto> Comments { get; set; }
    }
}
