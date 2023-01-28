using Microsoft.AspNetCore.Mvc;

namespace WebAppUi.Areas.Admin.Controllers;
[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
