using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityTimetable.Models
{
    public enum DayId : int
    {
        [Display(Name = "Poniedziałek")]
        Monday = 1,

        [Display(Name = "Wtorek")]
        Tuesday,

        [Display(Name = "Środa")]
        Wednesday,

        [Display(Name = "Czwartek")]

        Thursday,

        [Display(Name = "Piątek")]
        Friday,

        [Display(Name = "Sobota")]
        Saturday,

        [Display(Name = "Niedziela")]
        Sunday
    }
}
