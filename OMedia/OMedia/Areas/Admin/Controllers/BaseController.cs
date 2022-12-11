using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static OMedia.Areas.Admin.Constants.AdminConstants;
namespace OMedia.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {
    }
}
