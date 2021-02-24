using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityTimetable.Models
{
    public class Subject : BaseEntity
    {
        [Required]
        [Display(Name = "Nazwa przedmiotu")]
        public string Name { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
