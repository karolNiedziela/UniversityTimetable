using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Models;

namespace UniversityTimetable.Services
{
    public interface ILessonHourService
    {
        Task<LessonHour> GetAsync(int? id);

        Task<IEnumerable<LessonHour>> GetAllAsync();
    }
}
