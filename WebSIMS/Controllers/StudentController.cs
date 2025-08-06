using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSIMS.BDContext;
using WebSIMS.Models;

namespace WebSIMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly SIMSDBContext _context;

        public StudentController(SIMSDBContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách sinh viên
        public async Task<IActionResult> Index()
        {
            var students = await _context.StudentsDb.ToListAsync();
            return View(students);
        }

        // Hiển thị form tạo mới
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý tạo mới sinh viên
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.EnrollmentDate ??= DateTime.Now;
                _context.StudentsDb.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Hiển thị form sửa sinh viên
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.StudentsDb.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // Xử lý cập nhật sinh viên
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var existing = await _context.StudentsDb.FindAsync(student.StudentID);
                if (existing == null) return NotFound();

                existing.FirstName = student.FirstName;
                existing.LastName = student.LastName;
                existing.DateOfBirth = student.DateOfBirth;
                existing.Gender = student.Gender;
                existing.Email = student.Email;
                existing.Phone = student.Phone;
                existing.Address = student.Address;
                existing.Program = student.Program;
                existing.EnrollmentDate = student.EnrollmentDate;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Hiển thị xác nhận xóa
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.StudentsDb.FindAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // Xử lý xóa sinh viên
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.StudentsDb.FindAsync(id);
            if (student != null)
            {
                _context.StudentsDb.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
