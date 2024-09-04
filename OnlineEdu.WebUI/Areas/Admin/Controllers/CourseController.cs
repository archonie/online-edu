using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.DTOs.CourseCategoryDtos;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CourseController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task CategoryDropdown()
        {
            var courseCategoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories");
            List<SelectListItem> courseCategories = (from x in courseCategoryList
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.CourseCategoryId.ToString()
                                                        }
                                                     ).ToList();

            ViewBag.courseCategories = courseCategories;   
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");
            return View(values);
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _client.DeleteAsync($"courses/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            await CategoryDropdown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto dto)
        {
            await _client.PostAsJsonAsync("courses", dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateCourse(int id)
        {
            await CategoryDropdown();
            var value = await _client.GetFromJsonAsync<UpdateCourseDto>($"courses/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto dto)
        {
            await _client.PutAsJsonAsync("courses", dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnMainPage(int id)
        {
            await _client.GetAsync("courses/ShowOnMainPage/" + id);
            return RedirectToAction("Index");
        }
    }
}
