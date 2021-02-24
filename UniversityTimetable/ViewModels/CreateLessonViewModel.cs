using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityTimetable.ViewModels
{
    public class CreateLessonViewModel
    {
        public int DayId { get; set; }

        public int GroupId { get; set; }

        public int LessonHourId { get; set; }
    }
}
