using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Domain.Models
{
    public class CourseTeacher
    {
        public CourseTeacher(int teacherId, int schoolPeriodCourseId)
        {
            TeacherId = teacherId;
            SchoolPeriodCourseId = schoolPeriodCourseId;
        }

        public int TeacherId { get; set; }
        public Person Teacher { get; set; }
        public int SchoolPeriodCourseId { get; set; }
        public SchoolPeriodCourse SchoolPeriodCourse { get; set; }
    }
}
