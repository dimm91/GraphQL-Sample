using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Courses;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.Sample.Service.Services.Persons;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class CourseMutation
    {
        public record AddCourseInput(string Name, int DepartmentId);
        public async Task<Course> AddCourseAsync(
         [GraphQLNonNullType] AddCourseInput input,
         [Service] ICourseService courseService,
         [Service] IDepartmentService departmentService)
        {
            var department = await departmentService.GetDepartmentById(input.DepartmentId);

            if (department == null)
            {
                throw new Exception("The department does not exist");
            }

            return await courseService.InsertCourse(input.Name, input.DepartmentId);
        }
    }
}
