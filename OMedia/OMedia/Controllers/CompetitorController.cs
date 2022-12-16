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
        private readonly ICompetitorService competitorService;
        private readonly IAgeGroupService ageGroupService;


        public CompetitorController(
            IUserService _userService,
            ICompetitionService _competitionService,
            ICompetitorService _competitorService,
            IAgeGroupService _ageGroupService)
        {
            userService = _userService;
            competitionService = _competitionService;
            competitorService = _competitorService;
            ageGroupService = _ageGroupService;

        }

        public object MessageConstant { get; private set; }

        public async Task<IActionResult> Edit(int id)
        {
            var competitor = await userService.GetCompetitor(id);
            var competitorAGeGroup = await ageGroupService.GetAgeGroupId(id);
            var model = new CompetitorViewModel()
            {
                Name = competitor.Name,
                TeamId = competitor.Id,
                AgeGroupId = competitorAGeGroup,
                AgeGroups = await competitionService.GetAllAgeGroups(),
                Teams = await competitionService.GetAllTeams()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CompetitorViewModel model)
        {
            var competitorId = await userService.GetCompetitorId(User.Id());
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await competitorService.Edit(competitorId, model.Name, model.TeamId, model.AgeGroupId);

            return RedirectToAction("Profile", "User", new {id = User.Id()});
        }

        public async Task<IActionResult> Become()
        {
            if (await userService.isCompetitorById(User.Id()))
            {
                TempData[MessageConstants.WarningMessage] = "You are already a competitor";
                return RedirectToAction("Index", "Home");
            }
            var model = new CompetitorViewModel()
            {
                AgeGroups = await competitionService.GetAllAgeGroups(),
                Teams = await competitionService.GetAllTeams()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Become(CompetitorViewModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await competitorService.Create(userId, model.Name, model.TeamId, model.AgeGroupId);

            return RedirectToAction("Index", "Home");
        }


    }
}
