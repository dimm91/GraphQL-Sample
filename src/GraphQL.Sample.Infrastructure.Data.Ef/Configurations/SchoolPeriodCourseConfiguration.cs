using GraphQL.Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Configurations
{
    public class SchoolPeriodCourseConfiguration : IEntityTypeConfiguration<SchoolPeriodCourse>
    {
        public void Configure(EntityTypeBuilder<SchoolPeriodCourse> builder)
        {
            builder.HasKey(s => s.SchoolPeriodCourseId);

            builder.HasOne(s => s.Course)
                .WithMany(c => c.SchoolPeriodCourses)
                .HasForeignKey(s => s.CourseId);

            builder.HasOne(s => s.SchoolPeriod)
                .WithMany(sp => sp.SchoolPeriodCourses)
                .HasForeignKey(s => s.SchoolPeriodId);

            builder.HasData(new SchoolPeriodCourse(1, 2, 1, 3));
            builder.HasData(new SchoolPeriodCourse(2, 2, 2, 4));
            builder.HasData(new SchoolPeriodCourse(3, 2, 3, 4));
            builder.HasData(new SchoolPeriodCourse(4, 2, 4, 5));
            builder.HasData(new SchoolPeriodCourse(5, 2, 5, 5));
            builder.HasData(new SchoolPeriodCourse(6, 2, 6, 3));
            builder.HasData(new SchoolPeriodCourse(7, 2, 7, 3));
            builder.HasData(new SchoolPeriodCourse(8, 2, 8, 3));
            builder.HasData(new SchoolPeriodCourse(9, 2, 9, 4));
            builder.HasData(new SchoolPeriodCourse(10, 2, 10, 4));
            builder.HasData(new SchoolPeriodCourse(11, 2, 11, 4));
            builder.HasData(new SchoolPeriodCourse(12, 2, 12, 5));
            builder.HasData(new SchoolPeriodCourse(13, 2, 13, 5));
            builder.HasData(new SchoolPeriodCourse(14, 2, 14, 5));
            builder.HasData(new SchoolPeriodCourse(15, 1, 1, 5));
        }
    }
}
