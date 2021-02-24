using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Extensions.Alerts;
using UniversityTimetable.Models;
using UniversityTimetable.Services;
using UniversityTimetable.ViewModels;

namespace UniversityTimetable.Controllers
{
    public class LessonsController : Controller
    {
        private readonly IDayService _dayService;
        private readonly ILessonHourService _lessonHourService;
        private readonly ILessonService _lessonService;
        private readonly IGroupService _groupService;
        private readonly IRoomService _roomService;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;

        public LessonsController(ILessonService lessonService, IGroupService groupService,
            IRoomService roomService, ISubjectService subjectService, ITeacherService teacherService, IDayService dayService,
            ILessonHourService lessonHourService)
        {
            _dayService = dayService;
            _lessonHourService = lessonHourService;
            _lessonService = lessonService;
            _groupService = groupService;
            _roomService = roomService;
            _subjectService = subjectService;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var groups = await _groupService.GetAllAsync();

            var group = groups.FirstOrDefault();

            if (id is not null)
            {
                group = groups.SingleOrDefault(g => g.Id == id);
            }

            if (group is null)
            {
                return NotFound();
            }


            var timetable = new TimetableViewModel
            {
                Days = await _dayService.GetAllAsync(),
                LessonHours = await _lessonHourService.GetAllAsync(),
                Group = group,
                Groups = new SelectList(groups, "Id", "Name", group.Id.ToString()),
                Lessons = await _lessonService.GetAllAsync(l => l.GroupId == group.Id)
            };

            return View(timetable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexGroupId(Group group)
        {
            return RedirectToAction(nameof(Index), new { id = group.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int lessonHourId, int dayId, int groupId)
        {
            var createLesson = new CreateLessonViewModel
            {
                DayId = dayId,
                GroupId = groupId,
                LessonHourId = lessonHourId
            };

            return RedirectToAction(nameof(Create), createLesson);
        }

        [Authorize]
        public async Task<IActionResult> Create(CreateLessonViewModel createLesson)
        { 
            var timetableLesson = new LessonTimetableViewModel
            {
                Day = await _dayService.GetAsync(createLesson.DayId),
                Group = await _groupService.GetAsync(createLesson.GroupId),
                LessonHour = await _lessonHourService.GetAsync(createLesson.LessonHourId),
                Rooms = new SelectList(await _roomService.GetAllAsync(), "Id", "Number"),
                Subjects = new SelectList(await _subjectService.GetAllAsync(), "Id", "Name"),
                Teachers = new SelectList(await _teacherService.GetAllAsync(), "Id", "TitleIncluded")
            };

            return View(timetableLesson);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]LessonTimetableViewModel timetableLesson)
        {
            if (ModelState.IsValid)
            {
                var lesson = new Lesson(timetableLesson.DayId, timetableLesson.GroupId, timetableLesson.LessonHourId,
                    timetableLesson.RoomId, timetableLesson.SubjectId, timetableLesson.TeacherId);

                await _lessonService.AddAsync(lesson);
                return RedirectToAction(nameof(Index), new { id = lesson.GroupId })
                    .WithSuccess("Zajęcia zostały dodane pomyślnie.");
            }

            timetableLesson.Day = await _dayService.GetAsync(timetableLesson.DayId);
            timetableLesson.Group = await _groupService.GetAsync(timetableLesson.GroupId);
            timetableLesson.LessonHour = await _lessonHourService.GetAsync(timetableLesson.LessonHourId);
            timetableLesson.Rooms = new SelectList(await _roomService.GetAllAsync(), "Id", "Number", timetableLesson.RoomId);
            timetableLesson.Subjects = new SelectList(await _subjectService.GetAllAsync(), "Id", "Name", timetableLesson.SubjectId);
            timetableLesson.Teachers = new SelectList(await _teacherService.GetAllAsync(), "Id", "TitleIncluded", timetableLesson.TeacherId);

            return View(timetableLesson);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var lesson = await _lessonService.GetAsync(id);
            if (lesson is null)
            {
                return NotFound();
            }

            ViewBag.DayId = lesson.Day.DayName;
            ViewBag.GroupId = lesson.Group.Name;
            ViewBag.LessonHourId = lesson.LessonHour.HourName;
            ViewBag.RoomId = new SelectList(await _roomService.GetAllAsync(), "Id", "Number", lesson.RoomId);
            ViewBag.SubjectId = new SelectList(await _subjectService.GetAllAsync(), "Id", "Name", lesson.SubjectId);
            ViewBag.TeacherId = new SelectList(await _teacherService.GetAllAsync(), "Id", "TitleIncluded", lesson.TeacherId);
            return View(lesson);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, DayId, GroupId, LessonHourId, RoomId, SubjectId, TeacherId")]Lesson lesson)
        {

            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (await _lessonService.ExistAsync(l => l.TeacherId == lesson.TeacherId && l.DayId == lesson.DayId
                 && l.LessonHourId == lesson.LessonHourId))
            {
                ModelState.AddModelError("TeacherId", $"Prowadzący jest zajęty w ten dzień o tej godzinie.");
            }

            if (await _lessonService.ExistAsync(l => l.RoomId == lesson.RoomId && l.DayId == lesson.DayId
            && l.LessonHourId == lesson.LessonHourId))
            {
                ModelState.AddModelError("RoomId", $"Sala jest zajęta w ten dzień o tej godzinie.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _lessonService.UpdateAsync(lesson);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _lessonService.ExistAsync(l => l.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index), new { id = lesson.GroupId });
            }

            lesson = await _lessonService.GetAsync(id);

            ViewBag.DayId = lesson.Day.DayName;
            ViewBag.GroupId = lesson.Group.Name;
            ViewBag.LessonHourId = lesson.LessonHour.HourName;
            ViewBag.RoomId = new SelectList(await _roomService.GetAllAsync(), "Id", "Number", lesson.RoomId);
            ViewBag.SubjectId = new SelectList(await _subjectService.GetAllAsync(), "Id", "Name", lesson.SubjectId);
            ViewBag.TeacherId = new SelectList(await _teacherService.GetAllAsync(), "Id", "TitleIncluded", lesson.TeacherId);

            return View(lesson);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var lesson = await _lessonService.GetAsync(id);
            if (lesson is null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var lesson = await _lessonService.GetAsync(id);
            await _lessonService.RemoveAsync(lesson);

            return RedirectToAction(nameof(Index), new { id = lesson.GroupId })
                .WithDanger("Zajęcia zostały usunięte.");
        }
    }
}
