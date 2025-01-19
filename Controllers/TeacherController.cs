using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace efcoreApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DataContext _context;

        public TeacherController(DataContext dataContext)
        {
            _context = dataContext;
        }
        public IActionResult Index()
        {
            var data = _context.Teachers.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher model)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _context.Teachers.Include(x => x.Courses).FirstOrDefaultAsync(x => x.TeacherId == id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Teacher model)
        {
            if (id != model.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Teachers.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Teachers.Any(x => x.TeacherId == model.TeacherId))
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
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Teachers.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}