using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Models;

namespace UniversityTimetable.Data.Configuration.cs
{
    public class LessonHourConfiguration : BaseEntityConfiguration<LessonHour>
    {
        public override void Configure(EntityTypeBuilder<LessonHour> builder)
        {
            base.Configure(builder);

            builder.Property(lh => lh.Hour)
                   .HasConversion(
                    lh => lh.ToString(),
                    lh => (LessonHourId)Enum.Parse(typeof(LessonHourId), lh));

            builder.HasData(
                Enum.GetValues(typeof(LessonHourId))
                .Cast<LessonHourId>()
                .Select(lh => new LessonHour()
                {
                    Id = (int)lh,
                    Hour = lh
                })
           );
        }
    }
}
