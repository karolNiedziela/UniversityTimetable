using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Data.Configuration.cs;
using UniversityTimetable.Models;

namespace UniversityTimetable.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Day> Days { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<LessonHour> LessonHours { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DayConfiguration).Assembly);

            builder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new Role()
                {
                    Id = 2,
                    Name = "User",
                    NormalizedName = "USER"
                }
             );
        }

    }
}
