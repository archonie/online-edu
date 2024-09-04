using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.AboutDtos;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Validators;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class BlogCategoryController : Controller
	{
		private readonly HttpClient _client = HttpClientInstance.CreateClient();

		public async Task<IActionResult> Index()
		{

			var values = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogcategories");
			return View(values);
		}

		public async Task<IActionResult> DeleteBlogCategory(int id)
		{
			await _client.DeleteAsync($"blogcategories/{id}");
			return RedirectToAction(nameof(Index));
		}

		public IActionResult CreateBlogCategory()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateBlogCategory(CreateBlogCategoryDto dto)
		{
			var validator = new BlogCategoryValidator();
			var validationResult = await validator.ValidateAsync(dto);
			if (!validationResult.IsValid)
			{
				ModelState.Clear();
				foreach(var ex in validationResult.Errors)
				{
					ModelState.AddModelError(ex.PropertyName,ex.ErrorMessage);
				}
				return View();
			}
			await _client.PostAsJsonAsync("blogcategories", dto);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> UpdateBlogCategory(int id)
		{
			var values = await _client.GetFromJsonAsync<UpdateBlogCategoryDto>($"blogcategories/{id}");
			return View(values);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryDto dto)
		{
			var validator = new UpdateBlogCategoryValidator();
			var validationResult = await validator.ValidateAsync(dto);
			if (!validationResult.IsValid)
			{
				ModelState.Clear();
				foreach (var ex in validationResult.Errors)
				{
					ModelState.AddModelError(ex.PropertyName, ex.ErrorMessage);
				}
				return View();
			}
			await _client.PutAsJsonAsync("blogcategories", dto);
			return RedirectToAction(nameof(Index));
		}
	}
}
