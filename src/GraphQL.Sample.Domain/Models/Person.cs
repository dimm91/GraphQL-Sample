using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Domain.Models
{
    public class Person
    {
        public Person(int personId, string name, string lastname, string email, PersonType personType)
        {
            PersonId = personId;
            Name = name;
            Lastname = lastname;
            Email = email;
            PersonType = personType;

        }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public PersonType PersonType { get; set; }
        public virtual List<Department> Departments { get; set; }
        public virtual List<CourseStudent> CourseStudents { get; set; }
        public virtual List<CourseTeacher> CourseTeachers { get; set; }
    }

    public enum PersonType
    {
        Administrator,
        Teacher,
        Student
    }
}
