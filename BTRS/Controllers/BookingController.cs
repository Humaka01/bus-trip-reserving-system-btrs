using Microsoft.AspNetCore.Mvc;

namespace BTRS.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
