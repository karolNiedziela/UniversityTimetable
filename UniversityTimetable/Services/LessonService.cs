using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UniversityTimetable.Data;
using UniversityTimetable.Models;

namespace UniversityTimetable.Services
{
    public class LessonService : ILessonService
    {
        private readonly ApplicationDbContext _context;

        public LessonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Lesson> FindAsync(int id)
            => await _context.Lessons.FindAsync(id);

        public async Task<Lesson> GetAsync(int? id)
            => await _context.Lessons.Include(r => r.Day)
                                     .Include(r => r.Group)
                                     .Include(r => r.LessonHour)
                                     .Include(r => r.Room)
                                     .Include(r => r.Subject)
                                     .Include(r => r.Teacher)
                            .SingleOrDefaultAsync(l => l.Id == id);

        public async Task<IEnumerable<Lesson>> GetAllAsync(Expression<Func<Lesson, bool>> expression = null)
          => await _context.Lessons.Include(r => r.Day)
                                     .Include(r => r.Group)
                                     .Include(r => r.LessonHour)
                                     .Include(r => r.Room)
                                     .Include(r => r.Subject)
                                     .Include(r => r.Teacher)
                                     .Where(expression)
                            .ToListAsync();

        public async Task AddAsync(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Lesson lesson)
        {
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(Expression<Func<Lesson, bool>> expression)
            => await _context.Lessons.AnyAsync(expression);
    }
}
