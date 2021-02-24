using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UniversityTimetable.Data;
using UniversityTimetable.Extensions.Alerts;
using UniversityTimetable.Models;
using UniversityTimetable.Services;

namespace UniversityTimetable.Controllers
{
    [Authorize]
    public class SubjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISubjectService _subjectService;

        public SubjectsController(ApplicationDbContext context, ISubjectService subjectService)
        {
            _context = context;
            _subjectService = subjectService;
        }

        public async Task<IActionResult> Index()
        {
            var subjects = await _subjectService.GetAllAsync();
            return View(subjects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                var subjectCheck = await _subjectService.GetAsync(subject.Name);
                if (subjectCheck is not null)
                {
                    ModelState.AddModelError(string.Empty, $"Przedmiot o nazwie {subject.Name} został już dodany.");
                    return View(subject);
                }

                await _subjectService.AddAsync(subject);

                return RedirectToAction(nameof(Index)).WithSuccess("Przedmiot został dodany pomyślnie.");
            }

            return View(subject);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var subject = await _subjectService.GetAsync(id);
            if (subject is null)
            {
                return NotFound();
            }

            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name")] Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var subjectCheck = await _subjectService.GetAsync(subject.Name);
                    if (subjectCheck is not null)
                    {
                        ModelState.AddModelError(string.Empty, $"Przedmiot o nazwie {subject.Name} już istnieje.");
                        return View(subject);
                    }

                    await _subjectService.UpdateAsync(subject);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _subjectService.ExistAsync(id))
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

            return View(subject);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var subject = await _subjectService.GetAsync(id);
            if (subject is null)
            {
                return NotFound();
            }

            return View(subject);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _subjectService.RemoveAsync(id);

            return RedirectToAction(nameof(Index)).WithDanger("Przedmiot został usunięty.");
        }
    }
}
