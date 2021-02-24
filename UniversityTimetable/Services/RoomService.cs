using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Data;
using UniversityTimetable.Models;

namespace UniversityTimetable.Services
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Room> GetAsync(int? id)
            => await _context.Rooms.FindAsync(id);

        public async Task<Room> GetAsync(string number)
            => await _context.Rooms.SingleOrDefaultAsync(r => r.Number == number);

        public async Task<Room> GetRoomLessonsAsync(int? id)
        {
            var room = await _context.Rooms.Include(r => r.Lessons).ThenInclude(l => l.Day)
                                          .Include(r => r.Lessons).ThenInclude(l => l.Group)
                                          .Include(r => r.Lessons).ThenInclude(l => l.LessonHour)
                                          .Include(r => r.Lessons).ThenInclude(l => l.Subject)
                                          .Include(r => r.Lessons).ThenInclude(l => l.Teacher)
                                          .Select(r => new Room
                                          {
                                              Id = r.Id,
                                              Number = r.Number,
                                              Lessons = r.Lessons.OrderBy(l => l.Day.Id)
                                                  .ThenBy(l => l.Group.Id)
                                                  .ThenBy(l => l.LessonHour.Id).ToList()
                                          })
                                     .SingleOrDefaultAsync(r => r.Id == id);

            return room;
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            var rooms = await _context.Rooms.ToListAsync();

            return rooms.OrderBy(r => r.Number.PadLeft(rooms.Max(r => r.Number.Length), '0'));
        }

        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var room = await GetAsync(id);

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int id)
            => await _context.Rooms.AnyAsync(r => r.Id == id);

    }
}
