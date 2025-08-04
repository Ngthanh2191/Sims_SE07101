using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebSIMS.Controllers
{
    [Authorize] // bat buoc phai dang nhap 
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin, Student, Faculty")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
