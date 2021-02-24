using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Models;

namespace UniversityTimetable.Services
{
    public interface ISubjectService
    {
        Task<Subject> GetAsync(int? id);

        Task<Subject> GetAsync(string name);

        Task<IEnumerable<Subject>> GetAllAsync();

        Task AddAsync(Subject subject);

        Task RemoveAsync(int id);

        Task UpdateAsync(Subject subject);

        Task<bool> ExistAsync(int id);
    }
}
