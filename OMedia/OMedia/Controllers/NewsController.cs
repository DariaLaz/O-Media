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

        public NewsController(
            INewsService _newsService,
            IUserService _userService)
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
            if (await userService.isCompetitorById(User.Id()) == false)
            {
                return RedirectToAction("Become", "Competitor");
            }
            var model = new AddNewViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewViewModel model)
        {
            if (await userService.isCompetitorById(User.Id()) == false)
            {
                return RedirectToAction("Become", "Competitor");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int writerId = await userService.GetCompetitorId(User.Id());
            await newsService.Create(model, writerId);
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (((await newsService.Exists(id)) == false)
              || ((await newsService.GetWriterUserId(id)) != User.Id())
              || (await newsService.GetNewsById(id) == null))
            {
                return RedirectToAction(nameof(All));
            }

            var news = await newsService.GetNewsById(id);

            var model = new AddNewViewModel()
            {
                Content = news.Content,
                Title = news.Title
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddNewViewModel model)
        {
            if (((await newsService.Exists(id)) == false)
             || ((await newsService.GetWriterUserId(id)) != User.Id())
             || (await newsService.GetNewsById(id) == null))
            {
                return RedirectToAction(nameof(All));
            }

            await newsService.Edit(id, model);
            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (((await newsService.Exists(id)) == false)
             || ((await newsService.GetWriterUserId(id)) != User.Id())
             || (await newsService.GetNewsById(id) == null))
            {
                return RedirectToAction(nameof(All));
            }
            var news = await newsService.GetNewsById(id);

            var model = new NewsViewModel()
            {
                Content = news.Content,
                Title = news.Title
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, NewsViewModel model)
        {
            if (((await newsService.Exists(id)) == false)
             || ((await newsService.GetWriterUserId(id)) != User.Id())
             || (await newsService.GetNewsById(id) == null))
            {
                return RedirectToAction(nameof(All));
            }

            await newsService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}