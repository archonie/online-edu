using Humanizer;
using Microsoft.AspNetCore.Identity;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDtos;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto dto);
        Task<string> LoginAsync(UserLoginDto dto); 
        Task<bool> LogoutAsync();
        Task<bool> CreateRoleAsync(UserRoleDto dto);
        Task<bool> AssignRoleAsync(AssignRoleDto dto);
    }
}
