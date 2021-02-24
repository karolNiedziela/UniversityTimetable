using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityTimetable.Models
{
    public class Room : BaseEntity
    {
        [Required]
        [Display(Name = "Numer sali")]
        public string Number { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

    }
}
