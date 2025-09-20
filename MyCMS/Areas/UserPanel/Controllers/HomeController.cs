using Microsoft.AspNetCore.Mvc;

namespace MyCMS.Areas.UserPanel.Controllers
{ 
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
