using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Data;
using UniversityTimetable.Models;

namespace UniversityTimetable.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDbContext _context;

        public SubjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Subject> GetAsync(int? id)
            => await _context.Subjects.FindAsync(id);

        public async Task<Subject> GetAsync(string name)
            => await _context.Subjects.SingleOrDefaultAsync(s => s.Name == name);

        public async Task<IEnumerable<Subject>> GetAllAsync()
            => await _context.Subjects.OrderBy(s => s.Name).ToListAsync();

        public async Task AddAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var subject = await GetAsync(id);
             
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int id)
            => await _context.Subjects.AnyAsync(s => s.Id == id);
    }
}
