using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using UniversityTimetable.Data;
using UniversityTimetable.Extensions.Alerts;
using UniversityTimetable.Models;
using UniversityTimetable.Services;
using UniversityTimetable.ViewModels;

namespace UniversityTimetable.Controllers
{

    public class TeachersController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly ITeacherService _teacherService;
        private readonly IDayService _dayService;
        private readonly ILessonHourService _lessonHourService;

        public TeachersController(ApplicationDbContext context, ITeacherService teacherService,
            IDayService dayService, ILessonHourService lessonHourService)
        {
            _context = context;
            _teacherService = teacherService;
            _dayService = dayService;
            _lessonHourService = lessonHourService;
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherService.GetAllAsync();
            return View(teachers);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, ORCID, Title, FirstName, LastName")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var teacherCheck = await _teacherService.GetAsync(teacher.ORCID);
                if (teacherCheck is not null)
                {
                    ModelState.AddModelError(string.Empty, $"Identyfikator {teacher.ORCID} jest już przypisany do " +
                        $"{teacherCheck.TitleIncluded}.");
                    return View(teacher);
                }

                await _teacherService.AddAsync(teacher);
                return RedirectToAction(nameof(Index)).WithSuccess("Prowadzący został dodany pomyślnie.");
            }

            return View(teacher);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var teacher = await _teacherService.GetAsync(id);
            if (teacher is null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ORCID, Title, FirstName, LastName")]Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _teacherService.UpdateAsync(teacher);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _teacherService.ExistAsync(t => t.FirstName == teacher.FirstName && t.LastName == teacher.LastName))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var teacher = await _teacherService.GetAsync(id);
            if (teacher is null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _teacherService.RemoveAsync(id);

            return RedirectToAction(nameof(Index)).WithDanger("Prowadzący został usunięty.");
        }

        public IActionResult Search()
        {
            ViewBag.Days = new SelectList(_context.Days, "Id", "DayName");

             return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search([FromForm] TeacherSearchViewModel teacherSearch)
        {

            if (!await _teacherService.ExistAsync(t => t.FirstName == teacherSearch.FirstName &&
                t.LastName == teacherSearch.LastName))
            {
                ModelState.AddModelError(String.Empty, $"Nauczyciel {teacherSearch.FullName} nie istnieje.");
                return View(teacherSearch);
            }


            var teacher = await _teacherService.SearchAsync(teacherSearch.FirstName, teacherSearch.LastName);

            if (teacher.Lessons.Count == 0)
            {
                ModelState.AddModelError(String.Empty, $"Prowadzący {teacher.TitleIncluded} nie jeszcze przypisanych zajęć.");
                return View(teacherSearch);
            }

            var teacherTimetable = new TeacherTimetableViewModel
            {
                Days = await _dayService.GetAllAsync(),
                LessonHours = await _lessonHourService.GetAllAsync(),
                Teacher = teacher,
                Lessons = teacher.Lessons
            };

            return View("SearchResults", teacherTimetable);
        }

    }
}
