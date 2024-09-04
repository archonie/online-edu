using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDtos;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Controllers
{
    public class RegisterController(IUserService _service) : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(UserRegisterDto dto)
        {
            var result = await _service.CreateUserAsync(dto);
            if (!result.Succeeded || !ModelState.IsValid) {

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description); 
                }
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
