using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GraphQL.Sample.Domain.Models
{
    public class School
    {
        public School(int id, string name, string countryCode, string address)
        {
            Id = id;
            Name = name;
            CountryCode = countryCode;
            Address = address;

        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Address { get; set; }
        public List<Department> Departments { get; set; }
        public virtual List<SchoolPeriod> SchoolPeriods { get; set; }

    }
}
