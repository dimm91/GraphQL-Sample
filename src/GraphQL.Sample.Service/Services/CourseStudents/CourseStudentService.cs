using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.CourseStudents
{
    public class CourseStudentService : ICourseStudentService
    {
        private readonly ICourseStudentsRepository _courseStudentsRepository;
        public CourseStudentService(ICourseStudentsRepository courseStudentsRepository)
        {
            _courseStudentsRepository = courseStudentsRepository;
        }
        public async Task<IEnumerable<CourseStudent>> GetCourseStudentsByPeriodCourseId(IEnumerable<int> schoolPeriodCourseIds)
        {
            return await _courseStudentsRepository.GetListAsync(x => schoolPeriodCourseIds.Any(y => y == x.SchoolPeriodCourseId)); ;
        }
    }
}
