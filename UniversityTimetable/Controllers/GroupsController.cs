using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UniversityTimetable.Extensions.Alerts;
using UniversityTimetable.Models;
using UniversityTimetable.Services;

namespace UniversityTimetable.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        
        public async Task<IActionResult> Index()
        {
            var groups = await _groupService.GetAllAsync();

            return View(groups);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name")]Group group)
        {
            if (ModelState.IsValid)
            {
                var groupCheck = await _groupService.GetAsync(group.Name);
                if (groupCheck is not null)
                {
                    ModelState.AddModelError(string.Empty, $"Grupa studencka o numerze {group.Name} została już dodana.");
                    return View(group);
                }

                await _groupService.AddAsync(group);

                return RedirectToAction(nameof(Index)).WithSuccess("Grupa została dodana pomyślnie.");
            }

            return View(group);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var group = await _groupService.GetAsync(id);
            if (group is null)
            {
                return NotFound();
            }

            return View(group);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name")]Group group)
        {
            if (id != group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var groupCheck = await _groupService.GetAsync(group.Name);
                    if (groupCheck is not null)
                    {
                        ModelState.AddModelError(string.Empty, $"Przedmiot o nazwie {group.Name} już istnieje.");
                        return View(group);
                    }
                    
                    await _groupService.UpdateAsync(group);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _groupService.ExistsAsync(group.Id))
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

            return View(group);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var group = await _groupService.GetAsync(id);
            if (group is null)
            {
                return NotFound();
            }

            return View(group);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupService.RemoveAsync(id);

            return RedirectToAction(nameof(Index)).WithDanger("Grupa została usunięta.");
        }
    }
}
