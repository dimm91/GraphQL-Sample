using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.SchoolPeriodCourses
{
    public interface ISchoolPeriodCourseService
    {
        public Task<IEnumerable<SchoolPeriodCourse>> GetSchoolPeriodCoursesBySchoolPeriodIds(IEnumerable<int> schoolPeriodIds);
        public Task<SchoolPeriodCourse> GetSchoolPeriodCoursesById(int schoolPeriodCourseId);
        public Task<SchoolPeriodCourse> InsertSchoolPeriodCourse(int schoolPeriodId, int courseId, int credits);
    }
}
