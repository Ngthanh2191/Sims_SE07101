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

        // =================== INDEX ===================
        public async Task<IActionResult> Index()
        {
            var courses = await _context.CoursesDb.ToListAsync();
            return View(courses);
        }

        // =================== CREATE ===================
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Courses course)
        {
            if (!ModelState.IsValid) return View(course);

            course.CreatedAt = DateTime.Now;
            _context.CoursesDb.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // =================== EDIT ===================
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _context.CoursesDb.FindAsync(id);
            if (course == null) return NotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Courses course)
        {
            if (!ModelState.IsValid) return View(course);

            var existing = await _context.CoursesDb.FindAsync(course.CourseID);
            if (existing == null) return NotFound();

            // Cập nhật các field
            existing.CourseCode = course.CourseCode;
            existing.CourseName = course.CourseName;
            existing.Description = course.Description;
            existing.Credits = course.Credits;
            existing.Department = course.Department;
            existing.CreatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // =================== SEARCH ===================
        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return RedirectToAction("Index");

            query = query.Trim().ToLower();

            var results = await _context.CoursesDb
                .Where(c =>
                    (!string.IsNullOrEmpty(c.CourseName) && c.CourseName.ToLower().Contains(query)) ||
                    (!string.IsNullOrEmpty(c.CourseCode) && c.CourseCode.ToLower().Contains(query))
                )
                .ToListAsync();

            // Truyền thêm query để hiển thị lại ô input
            ViewBag.SearchQuery = query;

            return View("Index", results);
        }

        // =================== DELETE ===================
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.CoursesDb.FindAsync(id);
            if (course == null) return NotFound();

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
