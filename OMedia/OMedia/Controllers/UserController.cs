using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Contracts;
using OMedia.Extensions;

namespace OMedia.Controllers
{
    public class UserController : Controller
    {
        private readonly INewsService newsService;
        private readonly IUserService userService;

        public UserController(
           INewsService _newsService,
            IUserService _userService)
        {
            newsService = _newsService;
            userService = _userService;
        }

        public async Task<IActionResult> Profile(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Login");
            }   
            if (await userService.isCompetitorById(id) == false)
            {
                return RedirectToAction("Become", "Competition");
            }
            var compId = await userService.GetCompetitorId(id);
            var competitior = await userService.GetCompetitor(compId);

            competitior.News = (await newsService.GetNewsByUserId(id)).ToList();

            return View(competitior);
        }
    }
}
