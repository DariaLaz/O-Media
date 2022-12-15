using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Contracts;
using OMedia.Core.Models.User;
using OMedia.Extensions;
using OMedia.Models;
using System.Diagnostics;
using static OMedia.Areas.Admin.Constants.AdminConstants;

namespace OMedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;


        public HomeController(IUserService _userService)
        {
            userService = _userService;
        }
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            var model = new UserViewModel();

            if (User.Id() == null)
            {
                model.Name = "";
            }
            else
            {
                model = await userService.GetInfo(User.Id());
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}