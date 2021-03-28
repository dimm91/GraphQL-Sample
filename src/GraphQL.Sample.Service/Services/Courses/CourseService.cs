using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ISchoolPeriodCourseRepository _schoolPeriodCourseRepository;

        public CourseService(ICourseRepository courseRepository, ISchoolPeriodCourseRepository schoolPeriodCourseRepository)
        {
            _courseRepository = courseRepository;
            _schoolPeriodCourseRepository = schoolPeriodCourseRepository;
        }

        public async Task<IEnumerable<Course>> GetCourses(IEnumerable<int> courseIds)
        {
            return await _courseRepository.GetListAsync(c => courseIds.Any(ci => ci == c.Id));
        }
    }
}
