using Microsoft.AspNetCore.Mvc;
using OMedia.Core.Contracts;
using OMedia.Core.Services;
using OMedia.Models;
using System.Diagnostics;

namespace OMedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsFeedService homeService;

        public HomeController(INewsFeedService _homeService)
        {
            homeService = _homeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await homeService.GetNewsSortedByDate();

            return View(model);
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