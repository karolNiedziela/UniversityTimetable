using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Extensions;

namespace UniversityTimetable.Models
{
    public class Day : BaseEntity
    {
        [Display(Name = "Dzień tygodnia")]
        public DayId Name { get; set; }

        public string DayName { get { return Name.GetDisplayName(); } }

        public ICollection<Lesson> Lessons { get; set; }

        public static Day GetDay(string dayName)
            => Enum.GetValues(typeof(DayId))
                   .Cast<DayId>()
                   .Select(d => new Day()
                   {
                       Id = (int)d,
                       Name = d
                   }).SingleOrDefault(d => d.Name.ToString() == dayName);
                   
    }
}
