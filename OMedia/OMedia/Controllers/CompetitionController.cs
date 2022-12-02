using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Contracts;
using OMedia.Core.Models;
using OMedia.Core.Models.Competition;
using OMedia.Extensions;

namespace OMedia.Controllers
{
    [Authorize]
    public class CompetitionController : Controller
    {
        private readonly IUserService userService;
        private readonly ICompetitionService competitionService;
        public CompetitionController(
            IUserService _userService, 
            ICompetitionService _competitionService)
        {
            userService = _userService;
            competitionService = _competitionService;
        }
        public async Task<IActionResult> All()
        {
            var model = await competitionService.GetAllComingCompetitionsSortedByDate();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (await userService.ExistsById(User.Id()) == false)
            {
                return RedirectToAction("Login");
            }
            var arg = await competitionService.GetAllAgeGroups();
            var model = new AddCompetitionViewModel()
            {
                AgeGroupsCheckBoxes =
                arg.Select(ag => new CheckBoxOptions()
                {
                    Id = ag.Id,
                    IsChecked = false,
                    Description = $"{ag.Gender} {ag.Age}",
                    Value = ""
                }).ToList()
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCompetitionViewModel model)
        {
            if (await userService.ExistsById(User.Id()) == false)
            {
                return RedirectToAction("Login");
            }

            var arg = await competitionService.GetAllAgeGroups();

            model.AgeGroupsCheckBoxes =
            arg.Select(ag => new CheckBoxOptions()
            {
                Id = ag.Id,
                IsChecked = false,
                Description = $"{ag.Gender} {ag.Age}",
                Value = ""
            }).ToList();
            model.AgeGroups = model.AgeGroupsCheckBoxes.Where(c => c.IsChecked)
            .Select(ag => new CompetitionAgeGroupModel()
            {
                Id = ag.Id,
                Gender = ag.Description.Split(' ')[0],
                Age = int.Parse(ag.Description.Split(' ')[0])
            }).ToList();

            int userId = await userService.GetCompetitorId(User.Id());
            int id = await competitionService.Create(model, userId);
            return RedirectToAction("Login");

            //return RedirectToAction(nameof(Details), new { id });
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = new CompetitionViewModel();

            return View(model);
        }
    }
}
