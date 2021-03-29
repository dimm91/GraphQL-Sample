using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.CourseTeachers
{
    public class CourseTeacherService : ICourseTeacherService
    {
        private readonly ICourseTeacherRepository _courseTeacherRepository;
        public CourseTeacherService(ICourseTeacherRepository courseTeacherRepository)
        {
            _courseTeacherRepository = courseTeacherRepository;
        }

        public async Task<IEnumerable<CourseTeacher>> GetCourseTeachersByPeriodCourseId(IEnumerable<int> schoolPeriodCourseIds)
        {
            return await _courseTeacherRepository.GetListAsync(x => schoolPeriodCourseIds.Any(y => y == x.SchoolPeriodCourseId)); ;
        }

        public async Task<IEnumerable<CourseTeacher>> GetCourseTeachersByTeacherIds(IEnumerable<int> teacherIds)
        {
            return await _courseTeacherRepository.GetListAsync(x => teacherIds.Any(y => y == x.TeacherId));
        }

        public async Task<CourseTeacher> InsertCourseTeacher(int teacherId, int schoolPeriodCourseId)
        {
            var courseTeacher = new CourseTeacher(teacherId, schoolPeriodCourseId);
            await _courseTeacherRepository.CreateAsync(courseTeacher);
            return courseTeacher;
        }
    }
}
