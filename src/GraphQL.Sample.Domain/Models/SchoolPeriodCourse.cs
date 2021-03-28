using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Domain.Models
{
    public class SchoolPeriodCourse
    {
        public SchoolPeriodCourse(int schoolPeriodCourseId, int schoolPeriodId, int courseId, int credits)
        {
            SchoolPeriodCourseId = schoolPeriodCourseId;
            SchoolPeriodId = schoolPeriodId;
            CourseId = courseId;
            Credits = credits;
        }
        public int SchoolPeriodCourseId { get; set; }
        public int SchoolPeriodId { get; set; }
        public SchoolPeriod SchoolPeriod { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int Credits { get; set; }
        public virtual List<CourseStudent> CourseStudents { get; set; }
        public virtual List<CourseTeacher> CourseTeachers { get; set; }
    }
}
