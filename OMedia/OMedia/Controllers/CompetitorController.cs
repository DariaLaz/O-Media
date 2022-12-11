using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Contracts;
using OMedia.Extensions;
using OMedia.Core.Constants;
using OMedia.Core.Models.Competitor;


namespace OMedia.Controllers
{
    public class CompetitorController : Controller
    {
        private readonly IUserService userService;
        private readonly ICompetitionService competitionService;
        public CompetitorController(
            IUserService _userService,
            ICompetitionService _competitionService)
        {
            userService = _userService;
            competitionService = _competitionService;
        }

        public object MessageConstant { get; private set; }

        public async Task<IActionResult> Become()
        {
            if (await userService.isCompetitorById(User.Id()))
            {
                TempData[MessageConstants.WarningMessage] = "You are already a competitor";
                return RedirectToAction("Index", "Home");
            }
            var model = new BecomeCompetitorModel()
            {
                AgeGroups = await competitionService.GetAllAgeGroups(),
                Teams = await competitionService.GetAllTeams()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Become(BecomeCompetitorModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await userService.Create(userId, model.Name, model.TeamId, model.AgeGroupId);

            return RedirectToAction("Index", "Home");
        }
    }
}
