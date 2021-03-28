using GraphQL.Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DepartmentId);
            builder.Property(d => d.DepartmentId).ValueGeneratedOnAdd();

            builder.HasOne(d => d.Administrator)
                .WithMany(p => p.Departments)
                .HasForeignKey(d => d.AdministratorId);

            builder.HasMany(d => d.Courses);

            builder.HasData(new Department(1, "Economics", 1, 1));
            builder.HasData(new Department(2, "English", 2, 1));
            builder.HasData(new Department(3, "History", 2, 1));
            builder.HasData(new Department(4, "Engineering", 1, 1));
        }
    }
}
