using GraphQL.Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Configurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.SchoolPeriods)
                .WithOne(x => x.School)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new School(1, "School 1", "US", "-"));
            builder.HasData(new School(2, "Schule 2", "DE", "-"));
            builder.HasData(new School(3, "Escuela 1", "PE", "-"));
        }
    }
}
