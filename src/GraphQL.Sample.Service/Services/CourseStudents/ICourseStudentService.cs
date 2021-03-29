using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.CourseStudents
{
    public interface ICourseStudentService
    {
        Task<IEnumerable<CourseStudent>> GetCourseStudentsByPeriodCourseId(IEnumerable<int> schoolPeriodCourseIds);
        Task<CourseStudent> InsertCourseStudent(int studentId, int schoolPeriodCourseId);
    }
}
