using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.SchoolPeriodCourses
{
    public interface ISchoolPeriodCourseService
    {
        public Task<IEnumerable<SchoolPeriodCourse>> GetScholPeriodCoursesBySchoolPeriodIds(IEnumerable<int> schoolPeriodIds);
    }
}
