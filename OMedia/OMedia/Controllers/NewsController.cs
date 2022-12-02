using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Contracts;
using OMedia.Core.Models.News;
using OMedia.Extensions;

namespace OMedia.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private readonly INewsService newsService;
        private readonly IUserService userService;

        public NewsController(INewsService _newsService, IUserService _userService)
        {
            newsService = _newsService;
            userService = _userService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = await newsService.GetAllNewsSortedByDate();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            
            if (await userService.ExistsById(User.Id()) == false)
            {
                return RedirectToAction("Login");
            }
            var model = new AddNewViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewViewModel model)
        {
            if (await userService.ExistsById(User.Id()) == false)
            {
                return RedirectToAction("Login");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int writerId = await userService.GetCompetitorId(User.Id());
            int id = await newsService.Create(model, writerId);
            return RedirectToAction("All");
        }

    }
}
