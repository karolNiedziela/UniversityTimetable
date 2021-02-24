using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityTimetable.Models
{
    public enum LessonHourId : int
    {
        [Display(Name = "8-12")]
        EightToTen = 1,

        [Display(Name = "10-12")]
        TenToTwelve,

        [Display(Name = "12-14")]
        TwelveToFourteen,

        [Display(Name = "14-16")]
        FourteenToSixteen,

        [Display(Name = "16-18")]
        SixteenToEighteen,

        [Display(Name = "18-20")]
        EighteenToTwenty
    }
}
