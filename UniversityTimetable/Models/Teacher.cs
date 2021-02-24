using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityTimetable.Models
{
    public class Teacher : BaseEntity
    {
        [Required]
        [MaxLength(19, ErrorMessage = "Musi zawierać 19 znaków")]
        [RegularExpression("^\\d{4}-\\d{4}-\\d{4}-\\d{4}$", ErrorMessage = "Zły format indetyfikatora")]
        [Display(Name = "Identyfikator naukowy")]

        public string ORCID { get; set; }

        [Required]
        [Display(Name = "Tytuł naukowy")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        public string FullName
        { 
            get { return $"{FirstName} {LastName}"; }
        }

        public string TitleIncluded
        {
            get { return $"{Title} {FirstName} {LastName}"; }
        }

        public ICollection<Lesson> Lessons { get; set; }


        public override string ToString()
        {
            return $"{Title} {FirstName} {LastName}";
        }
    }
}
