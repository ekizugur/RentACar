using RentACar.Data.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services.Abstractions
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
        string GetUserName();
        Task ProfileUpdateAsync(UserDto userDto);
    }
}
