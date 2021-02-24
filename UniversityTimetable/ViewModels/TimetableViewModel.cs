using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Models;

namespace UniversityTimetable.ViewModels
{
    public class TimetableViewModel
    {
        public IEnumerable<Day> Days { get; set; }

        public IEnumerable<LessonHour> LessonHours { get; set; }

        public Group Group { get; set; }

        public SelectList Groups { get; set; }
        
        public IEnumerable<Lesson> Lessons { get; set; }
    }
}
