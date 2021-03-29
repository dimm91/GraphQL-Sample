using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Domain.Models
{
    public class Course
    {
        public Course(int id, string name, int departmentId) : this(name, departmentId)
        {
            Id = id;
        }
        public Course(string name, int departmentId)
        {
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
