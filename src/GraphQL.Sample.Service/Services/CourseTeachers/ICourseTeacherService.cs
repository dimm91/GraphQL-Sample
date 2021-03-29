using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.CourseTeachers
{
    public interface ICourseTeacherService
    {
        Task<IEnumerable<CourseTeacher>> GetCourseTeachersByPeriodCourseId(IEnumerable<int> schoolPeriodCourseIds);
        Task<IEnumerable<CourseTeacher>> GetCourseTeachersByTeacherIds(IEnumerable<int> teacherIds);
        Task<CourseTeacher> InsertCourseTeacher(int teacherId, int schoolPeriodCourseId);
    }
}
