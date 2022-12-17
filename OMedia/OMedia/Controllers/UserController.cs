using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Contracts;
using OMedia.Core.Models.User;
using OMedia.Extensions;

namespace OMedia.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly INewsService newsService;
        private readonly IUserService userService;
        private readonly UserManager<IdentityUser> userManager;
        public UserController(
           INewsService _newsService,
            IUserService _userService,
            UserManager<IdentityUser> _userManager)
        {
            newsService = _newsService;
            userService = _userService;
            userManager = _userManager;

        }

        public async Task<IActionResult> Profile(string id)
        {
            if (User.Id == null)
            {
                return RedirectToAction("Login");
            }
            if (await userService.isCompetitorById(id) == false)
            {
                return RedirectToAction("Become", "Competitor");
            }
            var compId = await userService.GetCompetitorId(id);
            var competitior = await userService.GetCompetitor(compId);

            competitior.News = (await newsService.GetNewsByUserId(id)).ToList();

            return View(competitior);
        }
    }
}
