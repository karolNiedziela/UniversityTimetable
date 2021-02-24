using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityTimetable.Models;

namespace UniversityTimetable.Services
{
    public interface IRoomService
    {
        Task<Room> GetAsync(int? id);

        Task<Room> GetAsync(string number);

        Task<Room> GetRoomLessonsAsync(int? id);

        Task<IEnumerable<Room>> GetAllAsync();

        Task AddAsync(Room room);

        Task RemoveAsync(int id);

        Task UpdateAsync(Room room);

        Task<bool> ExistAsync(int id);
    }
}