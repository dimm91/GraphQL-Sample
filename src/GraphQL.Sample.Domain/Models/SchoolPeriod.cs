using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GraphQL.Sample.Domain.Models
{
    public class SchoolPeriod
    {
        public SchoolPeriod(int schoolPeriodId, int schoolId, string period) : this(schoolId, period)
        {
            SchoolPeriodId = schoolPeriodId;
        }
        public SchoolPeriod(int schoolId, string period)
        {
            SchoolId = schoolId;
            Period = period;
        }

        public int SchoolPeriodId { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public string Period { get; set; }
        public virtual List<SchoolPeriodCourse> SchoolPeriodCourses { get; set; }
    }
}
