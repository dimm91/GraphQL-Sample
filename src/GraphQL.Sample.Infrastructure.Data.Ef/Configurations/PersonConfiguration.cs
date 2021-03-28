using GraphQL.Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.PersonId);
            builder.Property(p=>p.PersonId).ValueGeneratedOnAdd();

            builder.HasMany(p => p.Departments)
                .WithOne(d => d.Administrator)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Person(1, "Kim", "Abercrombie", "Kim.Abercrombie@email.com", PersonType.Administrator));
            builder.HasData(new Person(2, "Gytis", "Barzdukas", "Gytis.Barzdukas@email.com", PersonType.Administrator));
            builder.HasData(new Person(3, "Peggy", "Justice", "Peggy.Justice@email.com", PersonType.Student));
            builder.HasData(new Person(4, "Fadi", "Fakhouri", "Fadi.Fakhouri@email.com", PersonType.Student));
            builder.HasData(new Person(5, "Roger", "Harui", "Roger.Harui@email.com", PersonType.Student));
            builder.HasData(new Person(6, "Yan", "Li", "Yan.Li@email.com", PersonType.Student));
            builder.HasData(new Person(7, "Laura", "Norman", "Laura.Norman@email.com", PersonType.Student));
            builder.HasData(new Person(8, "Nino", "Olivotto", "Nino.Olivotto@email.com", PersonType.Teacher));
            builder.HasData(new Person(9, "Daniel", "Tang", "Daniel.Tang@email.com", PersonType.Teacher));
            builder.HasData(new Person(10, "Alonso", "Meredith", "Alonso.Meredith@email.com", PersonType.Teacher));
        }
    }
}
