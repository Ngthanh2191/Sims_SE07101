using Microsoft.AspNetCore.Mvc;

namespace WebSIMS.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
