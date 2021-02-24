using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversityTimetable.Services;
using UniversityTimetable.ViewModels;

namespace UniversityTimetable.Controllers
{
    public class RoomLessonsController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IDayService _dayService;
        private readonly ILessonHourService _lessonHourService;

        public RoomLessonsController(IRoomService roomService, IDayService dayService,
            ILessonHourService lessonHourService)
        {
            _roomService = roomService;
            _dayService = dayService;
            _lessonHourService = lessonHourService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var room = await _roomService.GetRoomLessonsAsync(id);

            var roomTimetable = new RoomTimetableViewModel
            {
                Days = await _dayService.GetAllAsync(),
                LessonHours = await _lessonHourService.GetAllAsync(),
                Room = room,
                Lessons = room.Lessons
            };

            return View(roomTimetable);
        }
    }
}
