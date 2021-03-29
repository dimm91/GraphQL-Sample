using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.SchoolPeriodCourses
{
    public class SchoolPeriodCourseService : ISchoolPeriodCourseService
    {
        private readonly ISchoolPeriodCourseRepository _schoolPeriodCourseRepository;
        public SchoolPeriodCourseService(ISchoolPeriodCourseRepository schoolPeriodCourseRepository)
        {
            _schoolPeriodCourseRepository = schoolPeriodCourseRepository;
        }

        public async Task<SchoolPeriodCourse> GetSchoolPeriodCoursesById(int schoolPeriodCourseId)
        {
            return await _schoolPeriodCourseRepository.GetElementAsync(spc => spc.SchoolPeriodCourseId == schoolPeriodCourseId);
        }

        public async Task<IEnumerable<SchoolPeriodCourse>> GetSchoolPeriodCoursesBySchoolPeriodIds(IEnumerable<int> schoolPeriodIds)
        {
            return await _schoolPeriodCourseRepository.GetListAsync(x => schoolPeriodIds.Any(a => a == x.SchoolPeriodId));
        }

        public async Task<SchoolPeriodCourse> InsertSchoolPeriodCourse(int schoolPeriodId, int courseId, int credits)
        {
            var schoolPeriodCourse = new SchoolPeriodCourse(schoolPeriodId, courseId, credits);
            await _schoolPeriodCourseRepository.CreateAsync(schoolPeriodCourse);
            return schoolPeriodCourse;
        }
    }
}
