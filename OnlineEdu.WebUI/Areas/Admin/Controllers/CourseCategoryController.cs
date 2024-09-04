using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseCategoryDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class CourseCategoryController : Controller
	{
		private readonly HttpClient _client = HttpClientInstance.CreateClient();
		public async Task<IActionResult> Index()
		{
			var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories");
			return View(values);
		}

		public async Task<IActionResult> DeleteCourseCategory(int id)
		{
			await _client.DeleteAsync($"courseCategories/{id}");
			return RedirectToAction(nameof(Index));
		}

		public IActionResult CreateCourseCategory()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCourseCategory(CreateCourseCategoryDto dto)
		{
			await _client.PostAsJsonAsync("courseCategories", dto);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> UpdateCourseCategory(int id)
		{
			var value = await _client.GetFromJsonAsync<UpdateCourseCategoryDto>($"courseCategories/{id}");
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateCourseCategory(UpdateCourseCategoryDto dto)
		{
			await _client.PutAsJsonAsync("courseCategories", dto);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> ShowOnMainPage(int id)
		{
			await _client.GetAsync("courseCategories/ShowOnMainPage/" + id);
			return RedirectToAction("Index");
		}
	}
}
