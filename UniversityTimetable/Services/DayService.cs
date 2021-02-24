using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Data;
using UniversityTimetable.Models;

namespace UniversityTimetable.Services
{
    public class DayService : IDayService
    {
        private readonly ApplicationDbContext _context;

        public DayService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Day> GetAsync(int? id)
            => await _context.Days.SingleOrDefaultAsync(d => d.Id == id);

        public async Task<IEnumerable<Day>> GetAllAsync()
            => await _context.Days.ToListAsync();
    }
}
