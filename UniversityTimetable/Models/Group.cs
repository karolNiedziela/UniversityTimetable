using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityTimetable.Models
{
    public class Group : BaseEntity
    {
        [Required]
        [Display(Name = "Numer grupy studenckiej")]
        public string Name { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
