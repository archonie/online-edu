using Microsoft.AspNetCore.Identity;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDtos;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public class UserService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<AppRole> _roleManager) : IUserService
    {
        public Task<bool> AssignRoleAsync(AssignRoleDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegisterDto dto)
        {

            var user = new AppUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                Email = dto.Email,
            };
            if (dto.Password != dto.ConfirmPassword)
            {
                return new IdentityResult();
            }
            return await _userManager.CreateAsync(user, dto.Password);
        }

        public async Task<string> LoginAsync(UserLoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            else {
                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                if (isAdmin)
                {
                    return "Admin";
                }
                var isTeacher = await _userManager.IsInRoleAsync(user, "Teacher");
                if (isTeacher)
                {
                    return "Teacher";
                }
                var isStudent = await _userManager.IsInRoleAsync(user, "Student");
                if (isStudent)
                {
                    return "Student";
                }
            }

            return null;
           
        }

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
