using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SubscriberDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
 
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SubscriberController : Controller {    

        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSubscriberDto>>("subscribers");
            return View(values);
        }

        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            await _client.DeleteAsync($"subscribers/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateSubscriber()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscriber(CreateSubscriberDto dto)
        {
            await _client.PostAsJsonAsync("subscribers", dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateSubscriber(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateSubscriberDto>($"subscribers/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscriber(UpdateSubscriberDto dto)
        {
            await _client.PutAsJsonAsync("subscribers", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
