using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Extensions;

namespace UniversityTimetable.Models
{
    public class LessonHour : BaseEntity
    {
        [Display(Name = "Godziny zajęć")]
        public LessonHourId Hour { get ; set; }

        public string HourName { get { return Hour.GetDisplayName(); } }

        public ICollection<Lesson> Lessons { get; set; }

        public static LessonHour GetLessonHour(string lessonHour)
            => Enum.GetValues(typeof(LessonHourId))
                .Cast<LessonHourId>()
                .Select(lh => new LessonHour
                {
                    Id = (int)lh,
                    Hour = lh
                }).SingleOrDefault(lh => lh.Hour.ToString() == lessonHour);
    }
}
