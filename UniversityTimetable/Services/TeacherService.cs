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
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext _context;

        public TeacherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> GetAsync(int? id)
            => await _context.Teachers.FindAsync(id);

        public async Task<Teacher> GetAsync(string ORCID)
            => await _context.Teachers.SingleOrDefaultAsync(t => t.ORCID == ORCID);

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            var teachers = await _context.Teachers.ToListAsync();

            return teachers.OrderBy(t => t.FullName);
        }

        public async Task AddAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var teacher = await GetAsync(id);

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(Expression<Func<Teacher, bool>> expression)
            => await _context.Teachers.AnyAsync(expression);

        public async Task<Teacher> SearchAsync(string firstName, string lastName)
        {
            var teacher = await _context.Teachers
                                        .Include(t => t.Lessons).ThenInclude(l => l.Day)
                                        .Include(t => t.Lessons).ThenInclude(l => l.Group)
                                        .Include(t => t.Lessons).ThenInclude(l => l.LessonHour)
                                        .Include(t => t.Lessons).ThenInclude(l => l.Room)
                                        .Include(t => t.Lessons).ThenInclude(l => l.Subject)
                                .Where(t => t.FirstName == firstName && t.LastName == lastName)
                                .FirstOrDefaultAsync();

            return teacher;
        }
    }
}
