using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UniversityTimetable.Extensions.Alerts;
using UniversityTimetable.Models;
using UniversityTimetable.Services;

namespace UniversityTimetable.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<IActionResult> Index()
        {
            var rooms = await _roomService.GetAllAsync();

            return View(rooms);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Number")]Room room)
        {
            if (ModelState.IsValid)
            {

                var roomCheck = await _roomService.GetAsync(room.Number);
                if (roomCheck is not null)
                {
                    ModelState.AddModelError(string.Empty, $"Sala o numerze {room.Number} został już dodany.");
                    return View(room);
                }

                await _roomService.AddAsync(room);

                return RedirectToAction(nameof(Index)).WithSuccess("Sala została dodany pomyślnie.");
            }

            return View(room);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var room = await _roomService.GetAsync(id);
            if (room is null)
            {
                return NotFound();
            }

            return View(room);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Number")]Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var roomCheck = await _roomService.GetAsync(room.Number);
                    if (room is not null)
                    {
                        ModelState.AddModelError(string.Empty, $"Pokój o numerze {room.Number} już istnieje.");
                        return View(room);
                    }

                    await _roomService.UpdateAsync(room);
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!await _roomService.ExistAsync(id))
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

            return View(room);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var room = await _roomService.GetAsync(id);
            if (room is null)
            {
                return NotFound();
            }

            return View(room);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomService.RemoveAsync(id);

            return RedirectToAction(nameof(Index)).WithDanger("Sala została usunięta.");
        }
    }
}
