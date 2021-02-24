using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Models;

namespace UniversityTimetable.ViewModels
{
    public class TeacherTimetableViewModel
    {
        public IEnumerable<Day> Days { get; set; }

        public IEnumerable<LessonHour> LessonHours { get; set; }

        public Teacher Teacher { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }
    }
}
