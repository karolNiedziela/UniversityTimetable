using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Models;

namespace UniversityTimetable.Services
{
    public interface IGroupService
    {
        Task<Group> GetAsync(int? id);

        Task<Group> GetAsync(string name);

        Task<IEnumerable<Group>> GetAllAsync();

        Task AddAsync(Group group);

        Task RemoveAsync(int id);

        Task UpdateAsync(Group group);

        Task<bool> ExistsAsync(int id);
    }
}
