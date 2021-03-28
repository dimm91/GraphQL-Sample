using GraphQL.Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId);

            builder.HasData(new Course(1, "Economic 1", 1));
            builder.HasData(new Course(2, "Economic 2", 1));
            builder.HasData(new Course(3, "Economic 3", 1));
            builder.HasData(new Course(4, "Economic 4", 1));
            builder.HasData(new Course(5, "Gramar 1", 2));
            builder.HasData(new Course(6, "Oral expression1", 2));
            builder.HasData(new Course(7, "Reading 1", 2));
            builder.HasData(new Course(8, "Reading 2", 2));
            builder.HasData(new Course(9, "National History 1", 3));
            builder.HasData(new Course(10, "National history 2", 3));
            builder.HasData(new Course(11, "Greek Mythology History 1", 3));
            builder.HasData(new Course(12, "Nordic Mythology History 2", 3));
            builder.HasData(new Course(13, "Computer Programming 1", 4));
            builder.HasData(new Course(14, "Databases 1", 4));
        }
    }
}
