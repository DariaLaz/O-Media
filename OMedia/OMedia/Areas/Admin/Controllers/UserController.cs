using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Constants;
using OMedia.Core.Contracts;
using OMedia.Extensions;

namespace OMedia.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly UserManager<IdentityUser> userManager;


        public UserController(IUserService _userService, UserManager<IdentityUser> userManager)
        {
            userService = _userService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            var model = await userService.All();
            model = model.Where(x => x.UserId != User.Id());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Forget(string userId)
        {
            var user = await userService.GetUser(userId);

            bool result = await userService.Forget(user);

            if (result)
            {
                TempData[MessageConstants.SuccessMessage] = "User is forgotten";
            }
            else
            {
                TempData[MessageConstants.ErrorMessage] = "User can not be forgotten";
            }

            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(string userId)
        {
            bool result = await userService.AddAdmin(userId);
            

            if (result)
            {
                TempData[MessageConstants.SuccessMessage] = "User is Admin";
            }
            else
            {
                TempData[MessageConstants.ErrorMessage] = "User can not be Admin";
            }

            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveAdmin(string userId)
        {
            if (await userService.IsTheLastAdmin())
            {
                TempData[MessageConstants.SuccessMessage] = "You can not remove the last Admin";
            }

            bool result = await userService.RemoveAdmin(userId);

            if (result)
            {
                TempData[MessageConstants.SuccessMessage] = "User is not longer Admin";
            }
            else
            {
                TempData[MessageConstants.ErrorMessage] = "User can not be removed as Admin";
            }

            return RedirectToAction(nameof(All));
        }
    }
}
