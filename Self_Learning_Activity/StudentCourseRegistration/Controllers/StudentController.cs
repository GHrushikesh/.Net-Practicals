using Microsoft.AspNetCore.Mvc;
using StudentCourseRegistration.Models;

namespace StudentCourseRegistration.Controllers
{
    public class StudentController : Controller
    {
        // In-memory data store for students
        private static readonly List<Student> _students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Aarav Sharma",
                Email = "aarav.sharma@marwadiuniversity.ac.in",
                Course = "B.Tech Computer Engineering",
                Semester = 5
            },
            new Student
            {
                Id = 2,
                Name = "Priya Patel",
                Email = "priya.patel@marwadiuniversity.ac.in",
                Course = "B.Tech Information Technology",
                Semester = 5
            },
            new Student
            {
                Id = 3,
                Name = "Rohan Mehta",
                Email = "rohan.mehta@marwadiuniversity.ac.in",
                Course = "B.Tech Computer Engineering",
                Semester = 3
            }
        };

        // GET: /Student or /Student/Index
        public IActionResult Index()
        {
            return View(_students);
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            // Model validation check using Data Annotations
            if (ModelState.IsValid)
            {
                // Auto-generate new unique ID
                student.Id = _students.Any() ? _students.Max(s => s.Id) + 1 : 1;
                _students.Add(student);

                TempData["SuccessMessage"] = $"Student '{student.Name}' registered successfully!";

                // Redirect to Student List page upon successful creation
                return RedirectToAction(nameof(Index));
            }

            // If validation failed, return the form with existing input and error messages
            return View(student);
        }

        // GET: /Student/Details/{id}
        public IActionResult Details(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
