using GraphQL.Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Configurations
{
    public class SchoolPeriodConfiguration : IEntityTypeConfiguration<SchoolPeriod>
    {
        public void Configure(EntityTypeBuilder<SchoolPeriod> builder)
        {
            builder.HasKey(sp => sp.SchoolPeriodId);
            builder.Property(sp => sp.SchoolPeriodId)
                .ValueGeneratedOnAdd();

            builder.HasOne(sp => sp.School)
                .WithMany(s => s.SchoolPeriods)
                .HasForeignKey(sp => sp.SchoolId);

            builder.HasMany(sp => sp.SchoolPeriodCourses)
                .WithOne(spc => spc.SchoolPeriod)
                .HasForeignKey(spc => spc.SchoolPeriodId);

            builder.HasData(new SchoolPeriod(1,1, "2020"));
            builder.HasData(new SchoolPeriod(2,1, "2021"));
        }
    }
}
