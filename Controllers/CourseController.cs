using System.Threading.Tasks;
using efcoreApp.Data;
using efcoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _context;

        public CourseController(DataContext dataContext)
        {
            _context = dataContext;
        }

        public IActionResult Index()
        {
            var data = _context.Courses.Include(x => x.Teacher).ToList();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {

            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "TeacherId", "FullName");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course model)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "TeacherId", "FullName");
            return View();
        }

        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "TeacherId", "FullName");

            var data = await _context.Courses
                                        .Include(x => x.Registration)
                                        .ThenInclude(x => x.Student)
                                        //.Select(k => new CourseViewModel
                                        //{
                                        //    CourseId = k.CourseId,
                                        //    Title = k.Title,
                                        //    TeacherId = k.TeacherId,
                                        //    Registration = k.Registration
                                        //})
                                        .FirstOrDefaultAsync(x => x.CourseId == id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Course model)
        {
            if (id != model.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Courses.Update(model/*new Course { CourseId = model.CourseId, Title = model.Title, TeacherId = model.TeacherId }*/);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Courses.Any(x => x.CourseId == model.CourseId))
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

            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "TeacherId", "FullName");
            return View(model);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Courses.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
