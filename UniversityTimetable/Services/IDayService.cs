using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Models;

namespace UniversityTimetable.Services
{
    public interface IDayService
    {
        Task<Day> GetAsync(int? id);

        Task<IEnumerable<Day>> GetAllAsync();
    }
}
