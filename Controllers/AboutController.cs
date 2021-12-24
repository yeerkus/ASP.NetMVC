using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}