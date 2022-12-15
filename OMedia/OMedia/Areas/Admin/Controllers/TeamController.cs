using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Contracts;
using OMedia.Core.Models.Team;

namespace OMedia.Areas.Admin.Controllers
{
    public class TeamController : BaseController
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
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddTeamModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTeamModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await teamService.Exists(model))
            {
                TempData["WarningMessage"] = "Team with the same name already exists";
            }

            int id = await teamService.Create(model);
            return RedirectToAction("All");
        }
    }
}
