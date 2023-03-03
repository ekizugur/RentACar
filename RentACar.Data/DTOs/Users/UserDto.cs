using Microsoft.AspNetCore.Http;
using RentACar.Data.DTOs.Images;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.DTOs.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public Guid? ImageId { get; set; }
        public Guid RoleId { get; set; }
        public string Role { get; set; }
        public Image Image { get; set; }
        public IFormFile Photo { get; set; }


    }
}
