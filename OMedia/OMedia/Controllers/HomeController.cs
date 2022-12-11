using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Contracts;
using OMedia.Extensions;
using OMedia.Models;
using System.Diagnostics;
using static OMedia.Areas.Admin.Constants.AdminConstants;

namespace OMedia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}