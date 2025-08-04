using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebSIMS.Controllers
{
    [Authorize] // bat buoc phai dang nhap
    public class CourseController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Admin, Student, Faculty")] 
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")] 
        public IActionResult Create()
        {
            return View();
        }
    }
}
