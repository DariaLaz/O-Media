using Microsoft.AspNetCore.Mvc;

namespace OMedia.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
