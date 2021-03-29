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
        public async Task<IEnumerable<CourseStudent>> GetCourseStudentsByStudentId(IEnumerable<int> studentIds)
        {
            return await _courseStudentsRepository.GetListAsync(x => studentIds.Any(y => y == x.StudentId));
        }

        public async Task<CourseStudent> InsertCourseStudent(int studentId, int schoolPeriodCourseId)
        {
            var courseStudent = new CourseStudent(studentId, schoolPeriodCourseId);
            await _courseStudentsRepository.CreateAsync(courseStudent);
            return courseStudent;
        }
    }
}
