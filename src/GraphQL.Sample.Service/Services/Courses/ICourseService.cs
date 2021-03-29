using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.Courses
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCourses(IEnumerable<int> courseIds);
        Task<Course> InsertCourse(string name, int departmentId);

    }
}
