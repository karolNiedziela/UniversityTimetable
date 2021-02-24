using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Models;

namespace UniversityTimetable.ViewModels
{
    public class LessonTimetableViewModel
    {
        public Day Day { get; set; }

        [Display(Name = "Dzień tygodnia")]
        public int DayId { get; set; }

        public Group Group { get; set; }

        [Display(Name = "Numer grupy studenckiej")]
        public int GroupId { get; set; }

        public LessonHour LessonHour { get; set; }

        [Display(Name = "Godziny zajęć")]
        public int LessonHourId { get; set; }

        public SelectList Rooms { get; set; }

        [Display(Name = "Numer sali")]
        public int RoomId { get; set; }

        public SelectList Subjects { get; set; }

        [Display(Name = "Nazwa przedmiotu")]
        public int SubjectId { get; set; }

        public SelectList Teachers { get; set; }

        [Display(Name = "Prowadzący")]
        public int TeacherId { get; set; }
    }
}
