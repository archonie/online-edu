using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDtos;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Controllers
{
    public class LoginController(IUserService _service) : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto dto)
        {
            var userRole = await _service.LoginAsync(dto);

            if (userRole == "Admin") {
                return RedirectToAction("Index", "About", new {area="Admin"});
            }
            if (userRole == "Teacher")
            {
                return RedirectToAction("Index", "MyCourse", new { area = "Teacher" });
            }
            if (userRole == "Student")
            {
                return RedirectToAction("Index", "CourseRegister", new { area = "Student" });
            }

            else
            {
                ModelState.AddModelError("", "Invalid Email or password.");
                return View();
            }

        }
    }
}
