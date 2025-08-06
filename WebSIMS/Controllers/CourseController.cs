using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSIMS.BDContext;
using WebSIMS.BDContext.Entities;

namespace WebSIMS.Controllers
{
    public class CourseController : Controller
    {
        private readonly SIMSDBContext _context;

        public CourseController(SIMSDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _context.CoursesDb.ToListAsync();
            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Courses course)
        {
            if (ModelState.IsValid)
            {
                course.CreatedAt = DateTime.Now;
                _context.CoursesDb.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var course = await _context.CoursesDb.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Courses course)
        {
            if (ModelState.IsValid)
            {
                var existing = await _context.CoursesDb.FindAsync(course.CourseID);
                if (existing == null) return NotFound();

                existing.CourseCode = course.CourseCode;
                existing.CourseName = course.CourseName;
                existing.Description = course.Description;
                existing.Credits = course.Credits;
                existing.Department = course.Department;
                existing.CreatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.CoursesDb.FindAsync(id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.CoursesDb.FindAsync(id);
            if (course != null)
            {
                _context.CoursesDb.Remove(course);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
