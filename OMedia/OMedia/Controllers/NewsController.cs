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
        public async Task<IActionResult> All([FromQuery] AllNewsQueryModel q)
        {
            var result = await newsService.GetAll(
                q.SearchTerm,
                q.Year,
                q.CurrentPage,
                AllNewsQueryModel.NewsPerPage);

            q.TotalNewsCount = result.TotalNewsCount;
            q.News = result.News;
            q.Years = await newsService.GetAllNewsYears();

            return View(q);
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

            return RedirectToAction(nameof(Details), new { id = id });
        }
        public async Task<IActionResult> Details(int id)
        {
            if (await userService.isCompetitorById(User.Id()) == false)
            {
                return RedirectToAction("Become", "Competitor");
            }
            if ((await newsService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await newsService.GetNewsById(id);

            return View(model);
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
        [HttpGet]
        public async Task<IActionResult> Comment(int id)
        {
            if (await userService.isCompetitorById(User.Id()) == false)
            {
                return RedirectToAction("Become", "Competitor");
            }
            var model = new AddCommentModel()
            {
                NewsId = id
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Comment(int id, AddCommentModel model)
        {
            if (await userService.isCompetitorById(User.Id()) == false)
            {
                return RedirectToAction("Become", "Competitor");
            }
            if (!(await newsService.Exists(id)))
            {
                return RedirectToAction("udshvusf");
            }

            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            int authorId = await userService.GetCompetitorId(User.Id());

            await newsService.CreateComment(model, authorId, id);

            return RedirectToAction(nameof(Details), new { id = model.NewsId });

        }

        [HttpGet]
        public async Task<IActionResult> EditComment(int id)
        {
            if (((await newsService.ExistsComment(id)) == false)
              || ((await newsService.GetCommentAuthorUserId(id)) != User.Id())
              || (await newsService.GetCommentById(id) == null))
            {
                return RedirectToAction(nameof(All));
            }

            var comment = await newsService.GetCommentById(id);

            var model = new EditCommentModel()
            {
                Id = id,
                Content = comment.Content,
                IsChanged = true,
                Date = DateTime.Now.ToString("dd/MM/yyyy")
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditComment(int id, EditCommentModel model)
        {

            await newsService.EditComment(id, model);

            return RedirectToAction(nameof(Details), new { id = model.NewsId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComment(int id)
        {
            if (((await newsService.ExistsComment(id)) == false)
              || ((await newsService.GetCommentAuthorUserId(id)) != User.Id())
              || (await newsService.GetCommentById(id) == null))
            {
                return RedirectToAction(nameof(All));
            }
            var comment = await newsService.GetCommentById(id);

            var model = new CommentViewModel()
            {
                Id = comment.Id,
                Content = comment.Content,
                AuthorId = comment.AuthorId,
                NewsId = comment.NewsId
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteComment(int id, CommentViewModel model)
        {
            if (((await newsService.ExistsComment(id)) == false)
              || ((await newsService.GetCommentAuthorUserId(id)) != User.Id())
              || (await newsService.GetCommentById(id) == null))
            {
                return RedirectToAction(nameof(All));
            }
            await newsService.DeleteComment(id);

            return RedirectToAction(nameof(Details), new { id = model.NewsId });
        }
    }
}