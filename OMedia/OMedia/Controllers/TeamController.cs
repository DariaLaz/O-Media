using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Contracts;
using OMedia.Core.Models.Team;
using OMedia.Extensions;

namespace OMedia.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;
        private readonly IUserService userService;

        public TeamController(
            ITeamService _teamService,
            IUserService _userService)
        {
            teamService = _teamService;
            userService = _userService;
        }
        public async Task<IActionResult> All()
        {
            var model = await teamService.GetAllTeams();
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            if ((await teamService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await teamService.TeamDetailsById(id);

            return View(model);
        }
    }
}
