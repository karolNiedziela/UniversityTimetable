using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityTimetable.Models
{
    public class Lesson : BaseEntity
    {

        [Display(Name = "Dzień tygodnia")]
        public int DayId { get; set; }

        public Day Day { get; set; }

        [Display(Name = "Numer grupy studenckiej")]
        public int GroupId { get; set; }

        public Group Group { get; set; }


        [Display(Name = "Godziny zajęć")]
        public int LessonHourId { get; set; }

        public LessonHour LessonHour { get; set; }

        [Display(Name = "Numer sali")]
        public int RoomId { get; set; }

        public Room Room { get; set; }

        [Display(Name = "Nazwa przedmiotu")]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        [Display(Name = "Prowadzący")]

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public Lesson()
        {

        }

        public Lesson(int dayId, int groupId, int lessonHourId, int roomId, int subjectId, int teacherId)
        {
            DayId = dayId;
            GroupId = groupId;
            LessonHourId = lessonHourId;
            RoomId = roomId;
            SubjectId = subjectId;
            TeacherId = teacherId;
        }

    }
}
