using GraphQL.Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Configurations
{
    public class CourseTeacherConfiguration : IEntityTypeConfiguration<CourseTeacher>
    {
        public void Configure(EntityTypeBuilder<CourseTeacher> builder)
        {
            builder.HasKey(x => new { x.SchoolPeriodCourseId, x.TeacherId });

            builder.HasOne(cs => cs.Teacher)
                .WithMany(p => p.CourseTeachers)
                .HasForeignKey(cs => cs.TeacherId);

            builder.HasOne(cs => cs.SchoolPeriodCourse)
                .WithMany(spc => spc.CourseTeachers)
                .HasForeignKey(cs => cs.SchoolPeriodCourseId);

            builder.HasData(new CourseTeacher(8, 1));
            builder.HasData(new CourseTeacher(9, 2));
            builder.HasData(new CourseTeacher(10, 2));
            builder.HasData(new CourseTeacher(10, 3));
            builder.HasData(new CourseTeacher(8, 7));
        }
    }
}
