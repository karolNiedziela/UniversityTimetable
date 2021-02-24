using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Data;
using UniversityTimetable.Models;

namespace UniversityTimetable.Services
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Group> GetAsync(int? id)
            => await _context.Groups.FindAsync(id);

        public async Task<Group> GetAsync(string name)
            => await _context.Groups.SingleOrDefaultAsync(g => g.Name == name);

        public async Task<IEnumerable<Group>> GetAllAsync()
            => await _context.Groups.OrderBy(g => g.Name).ToListAsync();

        public async Task AddAsync(Group group)
        {
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var group = await GetAsync(id);

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
            => await _context.Groups.AnyAsync(g => g.Id == id);
        
    }
}
