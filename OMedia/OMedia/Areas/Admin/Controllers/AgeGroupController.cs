using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Contracts;
using OMedia.Core.Models.AgeGroup;

namespace OMedia.Areas.Admin.Controllers
{
    public class AgeGroupController : BaseController
    {
        private readonly IAgeGroupService ageGroupService;
        private readonly IUserService userService;

        public AgeGroupController(
            IAgeGroupService _ageGroupService,
            IUserService _userService)
        {
            ageGroupService = _ageGroupService;
            userService = _userService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await ageGroupService.All();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AgeGroupViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AgeGroupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await ageGroupService.Exists(model))
            {
                TempData["WarningMessage"] = "Age group with the same gender and age already exists";
            }
            int id = await ageGroupService.Create(model);
            return RedirectToAction("All");
        }
    }
}
