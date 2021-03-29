using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Courses;
using GraphQL.Sample.Service.Services.CourseStudents;
using GraphQL.Sample.Service.Services.CourseTeachers;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.Sample.Service.Services.Persons;
using GraphQL.Sample.Service.Services.SchoolPeriodCourses;
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
        public record AddCourseStudentInput(int StudentId, int ScholPeriodCourseId);
        public record AddCourseTeacherInput(int TeacherId, int ScholPeriodCourseId);

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

        public async Task<CourseStudent> AddCourseStudentAsync(
       [GraphQLNonNullType] AddCourseStudentInput input,
       [Service] ICourseStudentService courseStudentService,
       [Service] ISchoolPeriodCourseService schoolPeriodCourseService,
       [Service] IPersonService personService)
        {
            var person = await personService.GetPersonById(input.StudentId, PersonType.Student);

            if (person == null)
            {
                throw new Exception("The person does not exist");
            }

            var schoolPeriodCourse = await schoolPeriodCourseService.GetSchoolPeriodCoursesById(input.ScholPeriodCourseId);
            if (schoolPeriodCourse == null)
            {
                throw new Exception("The course period does not exist");
            }

            return await courseStudentService.InsertCourseStudent(input.StudentId, input.ScholPeriodCourseId);
        }

        public async Task<CourseTeacher> AddCourseTeacherAsync(
       [GraphQLNonNullType] AddCourseTeacherInput input,
       [Service] ICourseTeacherService courseTeacherService,
       [Service] ISchoolPeriodCourseService schoolPeriodCourseService,
       [Service] IPersonService personService)
        {
            var person = await personService.GetPersonById(input.TeacherId, PersonType.Teacher);

            if (person == null)
            {
                throw new Exception("The person does not exist");
            }

            var schoolPeriodCourse = await schoolPeriodCourseService.GetSchoolPeriodCoursesById(input.ScholPeriodCourseId);
            if (schoolPeriodCourse == null)
            {
                throw new Exception("The course period does not exist");
            }

            return await courseTeacherService.InsertCourseTeacher(input.TeacherId, input.ScholPeriodCourseId);
        }
    }
}
