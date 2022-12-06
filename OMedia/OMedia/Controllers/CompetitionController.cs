using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Constants;
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
            if (await userService.isCompetitorById(User.Id()) == false)
            {
                TempData[MessageConstants.WarningMessage] = "You should be Competitor to access that resourse.";
                return RedirectToAction("Become", "Competitor");
            }
            var model = await competitionService.GetAllComingCompetitionsSortedByDate();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (await userService.isCompetitorById(User.Id()) == false)
            {
                return RedirectToAction("Become", "Competitor");
            }
            var arg = await competitionService.GetAllAgeGroups();
            var model = new AddCompetitionViewModel()
            {
                AgeGroupsCheckBoxes =
                    arg.Select(ag => new CheckBoxOptions()
                    {
                        Id = ag.Id,
                        IsChecked = true,
                        Gender = ag.Gender,
                        Age = ag.Age
                    }).ToList()
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCompetitionViewModel model)
        {
            if (await userService.isCompetitorById(User.Id()) == false)
            {
                return RedirectToAction("Become", "Competitor");
            }
            if (await userService.isCompetitorById(User.Id()) == false)
            {
                return RedirectToAction("Login");
            }
            var ageGroups = new List<CompetitionAgeGroupModel>();
            foreach (var agId in model.AgeGroupString)
            {
                var currAgeGroup = await competitionService.GetAgeGroupsById(int.Parse(agId));
                ageGroups.Add(new CompetitionAgeGroupModel()
                {
                    Id=currAgeGroup.Id,
                    Age = currAgeGroup.Age?? 0,
                    Gender = currAgeGroup.Gender
                });
            }
            model.AgeGroups = ageGroups;

            int userId = await userService.GetCompetitorId(User.Id());
            int id = await competitionService.Create(model, userId);
            return RedirectToAction(nameof(Details), new {id = id});
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (await userService.isCompetitorById(User.Id()) == false)
            {
                return RedirectToAction("Become", "Competitor");
            }
            if ((await competitionService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await competitionService.CompetitionDetailsById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (((await competitionService.Exists(id)) == false)
              ||((await competitionService.GetCompetitionOrganizerUserId(id)) != User.Id())
              ||((await competitionService.GetCompetitionById(id)) == null))
            {
                return RedirectToAction(nameof(All));
            }

            var competition = await competitionService.GetCompetitionById(id);
            var arg = await competitionService.GetAllAgeGroups();


            var model = new AddCompetitionViewModel()
            {
                Name = competition.Name,
                Location = competition.Location,
                Date = competition.Date,
                Details = competition.Details,
                AgeGroups = new List<CompetitionAgeGroupModel>()
            };

            foreach (var g in competition.AgeGroups)
            {
                model.AgeGroups.Add(new CompetitionAgeGroupModel()
                {
                    Id = g.AgeGroupId,
                    Gender = (await competitionService.GetAgeGroupsById(g.AgeGroupId)).Gender,
                    Age = (await competitionService.GetAgeGroupsById(g.AgeGroupId)).Age
                });
            }

            model.AgeGroupsCheckBoxes =
                    arg.Select(ag => new CheckBoxOptions()
                    {
                        Id = ag.Id,
                        IsChecked = (competition.AgeGroups.Any(x => x.AgeGroupId == ag.Id)),
                        Gender = ag.Gender,
                        Age = ag.Age
                    }).ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddCompetitionViewModel model)
        {
            if (((await competitionService.Exists(id)) == false)
             || ((await competitionService.GetCompetitionOrganizerUserId(id)) != User.Id())
             || ((await competitionService.GetCompetitionById(id)) == null))
            {
                return RedirectToAction(nameof(All));
            }
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var validIds = new List<int>();
            model.AgeGroups = new List<CompetitionAgeGroupModel>();
            foreach (var agId in model.AgeGroupString)
            {
                var currAgeGroup = await competitionService.GetAgeGroupsById(int.Parse(agId));
                validIds.Add(currAgeGroup.Id);
                if (model.AgeGroups.Any(x => x.Id == currAgeGroup.Id))
                {
                    model.AgeGroups.Add(new CompetitionAgeGroupModel()
                    {
                        Id = currAgeGroup.Id,
                        Age = currAgeGroup.Age ?? 0,
                        Gender = currAgeGroup.Gender == null ? "Open" : currAgeGroup.Gender
                    });
                }
            }
            foreach (var ag in model.AgeGroups)
            {
                if (validIds.Contains(ag.Id))
                {
                    await competitionService.RemoveAgeGroup(id, ag.Id);
                }
            }

            await competitionService.Edit(id, model);
            return RedirectToAction(nameof(Details), new { id = id });

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (((await competitionService.Exists(id)) == false)
             || ((await competitionService.GetCompetitionOrganizerUserId(id)) != User.Id())
             || ((await competitionService.GetCompetitionById(id)) == null))
            {
                return RedirectToAction(nameof(All));
            }
            var competition = await competitionService.GetCompetitionById(id);
            var arg = await competitionService.GetAllAgeGroups();


            var model = new CompetitionViewModel()
            {
                Name = competition.Name,
                Location = competition.Location,
                Date = competition.Date.ToString("dd/MM/yyyy"),
                AgeGroups = new List<CompetitionAgeGroupModel>()
            };

            foreach (var g in competition.AgeGroups)
            {
                model.AgeGroups.ToList().Add(new CompetitionAgeGroupModel()
                {
                    Id = g.AgeGroupId,
                    Gender = (await competitionService.GetAgeGroupsById(g.AgeGroupId)).Gender,
                    Age = (await competitionService.GetAgeGroupsById(g.AgeGroupId)).Age
                });
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CompetitionViewModel model)
        {
            if (((await competitionService.Exists(id)) == false)
             || ((await competitionService.GetCompetitionOrganizerUserId(id)) != User.Id())
             || ((await competitionService.GetCompetitionById(id)) == null))
            {
                return RedirectToAction(nameof(All));
            }

            await competitionService.Delete(id);

            return RedirectToAction(nameof(All));
        }

    }
}
