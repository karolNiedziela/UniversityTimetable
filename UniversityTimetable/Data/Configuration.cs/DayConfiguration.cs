using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTimetable.Models;

namespace UniversityTimetable.Data.Configuration.cs
{
    public class DayConfiguration : BaseEntityConfiguration<Day>
    {
        public override void Configure(EntityTypeBuilder<Day> builder)
        {
            base.Configure(builder);

            builder.Property(d => d.Name)
                   .HasConversion(
                   d => d.ToString(),
                   d => (DayId)Enum.Parse(typeof(DayId), d));

            builder.HasData(
                Enum.GetValues(typeof(DayId))
                .Cast<DayId>()
                .Select(d => new Day()
                {
                    Id = (int)d,
                    Name = d
                })
            );
        }
    }
}
