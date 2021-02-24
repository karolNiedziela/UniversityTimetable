using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Models;

namespace UniversityTimetable.ViewModels
{
    public class RoomTimetableViewModel
    {
        public IEnumerable<Day> Days { get; set; }

        public IEnumerable<LessonHour> LessonHours { get; set; }

        public Room Room { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }
    }
}
