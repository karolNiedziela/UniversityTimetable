using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UniversityTimetable.Models;
using UniversityTimetable.ViewModels;

namespace UniversityTimetable.Services
{
    public interface ILessonService
    {
        Task<Lesson> FindAsync(int id);

        Task<Lesson> GetAsync(int? id);

        Task<IEnumerable<Lesson>> GetAllAsync(Expression<Func<Lesson, bool>> expression = null);

        Task AddAsync(Lesson lesson);

        Task RemoveAsync(Lesson lesson);

        Task UpdateAsync(Lesson lesson);

        Task<bool> ExistAsync(Expression<Func<Lesson, bool>> expression);
    }
}
