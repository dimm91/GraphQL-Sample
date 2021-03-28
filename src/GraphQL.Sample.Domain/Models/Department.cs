using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Domain.Models
{
    public class Department
    {
        public Department(int departmentId, string name, int administratorId, int schoolId)
        {
            DepartmentId = departmentId;
            Name = name;
            AdministratorId = administratorId;
            SchoolId = schoolId;
        }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int AdministratorId { get; set; }
        public Person Administrator { get; set; }
        public List<Course> Courses { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
