using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Domain.Models
{
    public class Course
    {
        public Course(int id, string name, int departmentId)
        {
            Id = id;
            Name = name;
            DepartmentId = departmentId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<SchoolPeriodCourse> SchoolPeriodCourses { get; set; }
    }
}
