using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UniversityTimetable.Models;

namespace UniversityTimetable.Services
{
    public interface ITeacherService
    {
        Task<Teacher> GetAsync(int? id);

        Task<Teacher> GetAsync(string ORCID);

        Task<IEnumerable<Teacher>> GetAllAsync();

        Task AddAsync(Teacher teacher);

        Task RemoveAsync(int id);

        Task UpdateAsync(Teacher teacher);

        Task<bool> ExistAsync(Expression<Func<Teacher, bool>> expression);

        Task<Teacher> SearchAsync(string firstName, string lastName);

    }
}
