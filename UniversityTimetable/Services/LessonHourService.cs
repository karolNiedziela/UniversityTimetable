using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Data;
using UniversityTimetable.Models;

namespace UniversityTimetable.Services
{
    public class LessonHourService : ILessonHourService
    {
        private readonly ApplicationDbContext _context;

        public LessonHourService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LessonHour> GetAsync(int? id)
            => await _context.LessonHours.SingleOrDefaultAsync(lh => lh.Id == id);

        public async Task<IEnumerable<LessonHour>> GetAllAsync()
            => await _context.LessonHours.ToListAsync();
    }
}
