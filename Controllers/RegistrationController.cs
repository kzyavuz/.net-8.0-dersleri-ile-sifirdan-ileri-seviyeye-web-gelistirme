using System.Threading.Tasks;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly DataContext _context;

        public RegistrationController(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Registrations.Include(x => x.Student).Include(x => x.Course).ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            var students = await _context.Students.ToListAsync();
            var courses = await _context.Courses.ToListAsync();

            if (students == null || !students.Any())
                throw new Exception("Öğrenci Kayıdı Bulunamadı");
            if (courses == null || !courses.Any())
                throw new Exception("Kurs kayıdı bulunamadı");

            ViewBag.Students = new SelectList(students, "StudentId", "FullName");
            ViewBag.Courses = new SelectList(courses, "CourseId", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Registration model)
        {
            if (ModelState.IsValid)
            {
                model.RegistrationDateTime = DateTime.Now;
                _context.Registrations.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Students = new SelectList(await _context.Students.ToListAsync(), "StudentId", "FullName");
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId", "Title");
            return View(model);
        }

        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = _context.Registrations.Find(id);

            if (data == null)
            {
                return NotFound();
            }

            ViewBag.Students = new SelectList(await _context.Students.ToListAsync(), "StudentId", "FullName");
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId", "Title");

            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Registration model)
        {
            if (id != model.RegistrationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Registrations.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Registrations.Any(x => x.RegistrationId == model.RegistrationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Registrations.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            _context.Registrations.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}