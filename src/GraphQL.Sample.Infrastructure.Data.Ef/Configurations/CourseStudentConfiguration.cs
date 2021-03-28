using GraphQL.Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Configurations
{
    public class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {
            builder.HasKey(cs => new { cs.SchoolPeriodCourseId, cs.StudentId });

            builder.HasOne(cs => cs.Student)
                .WithMany(p => p.CourseStudents)
                .HasForeignKey(cs => cs.StudentId);

            builder.HasOne(cs => cs.SchoolPeriodCourse)
                .WithMany(spc => spc.CourseStudents)
                .HasForeignKey(cs => cs.SchoolPeriodCourseId);

            builder.HasData(new CourseStudent(3, 1));
            builder.HasData(new CourseStudent(4, 1));
            builder.HasData(new CourseStudent(5, 1));
            builder.HasData(new CourseStudent(6, 2));
            builder.HasData(new CourseStudent(7, 2));
            builder.HasData(new CourseStudent(5, 2));
            builder.HasData(new CourseStudent(6, 3));
            builder.HasData(new CourseStudent(5, 3));
            builder.HasData(new CourseStudent(4, 4));
            builder.HasData(new CourseStudent(3, 7));
        }
    }
}
