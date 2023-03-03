using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RentACar.Data.DTOs.Users;
using RentACar.Entity.Entities;
using System.Data;

namespace RentACar.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;

        public UserController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager,IMapper mapper,IToastNotification toast)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var userDtos = mapper.Map<List<UserDto>>(users);

            foreach (var userDto in userDtos)
            {
                var user = await userManager.FindByIdAsync((userDto.Id).ToString());
                var role =string.Join("-",await userManager.GetRolesAsync(user));
                userDto.Role = role;
            }
            return View(userDtos);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            
            if(user == null)
            {
                return NotFound();
            }

            var roles=await roleManager.Roles.ToListAsync();
            
            var map = mapper.Map<UserUpdateDto>(user);
            map.Roles= roles;
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await userManager.FindByIdAsync(userUpdateDto.Id.ToString());
            if(user != null)
            {
                var userRole = string.Join("", await userManager.GetRolesAsync(user));
                var roles = await roleManager.Roles.ToListAsync();
                if (ModelState.IsValid)
                {
                    mapper.Map(userUpdateDto, user);
                    user.UserName = userUpdateDto.Email;
                    user.PhoneNumber= userUpdateDto.PhoneNumber;
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    var result = await userManager.UpdateAsync(user);
                    if(result.Succeeded)
                    {
                        await userManager.RemoveFromRoleAsync(user,userRole);
                        var findRole=await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                        await userManager.AddToRoleAsync(user, findRole.Name);
                        toast.AddSuccessToastMessage("Kullanıcı başarıyla güncellendi", new ToastrOptions { Title = "İşlem başarılı" });
                        return RedirectToAction("Index", "User", new { Area = "Admin" });
                    }
                    else
                    {
                        foreach (var errors in result.Errors)
                        {
                            ModelState.AddModelError("", errors.Description);
                            return View(new UserUpdateDto { Roles = roles });
                        }
                    }
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    toast.AddSuccessToastMessage("Kullanıcı başarıyla silindi!", new ToastrOptions { Title = "Başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    foreach (var errors in result.Errors)
                    {
                        ModelState.AddModelError("", errors.Description);
                        
                    }
                }
            
            return NotFound();
        }
    }
}
