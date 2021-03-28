using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Domain.Models
{
    public class CourseStudent
    {
        public CourseStudent(int studentId, int schoolPeriodCourseId)
        {
            StudentId = studentId;
            SchoolPeriodCourseId = schoolPeriodCourseId;
        }

        public int StudentId { get; set; }
        public virtual Person Student { get; set; }
        public int SchoolPeriodCourseId { get; set; }
        public virtual SchoolPeriodCourse SchoolPeriodCourse { get; set; }
    }
}
