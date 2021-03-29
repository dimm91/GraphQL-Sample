using GraphQL.DotNet.Sample.GraphQL.InputTypes;
using GraphQL.DotNet.Sample.GraphQL.Types;
using GraphQL.Sample.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Mutations
{
    internal partial class RootMutation
    {
        public void SetCourseMutations()
        {
            Field<CourseGraphType>(
              "AddCourse", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AddCourseInputType>> { Name = "input" }),
              resolve: c => AddCourseAsync(c.GetArgument<AddCourseInput>("input")));

            Field<CourseStudentGraphType>(
              "AddCourseStudent", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AddCourseStudentInputType>> { Name = "input" }),
              resolve: c => AddCourseStudentAsync(c.GetArgument<AddCourseStudentInput>("input")));

            Field<CourseTeacherGraphType>(
              "AddCourseTeacher", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AddCourseTeacherInputType>> { Name = "input" }),
              resolve: c => AddCourseTeacherAsync(c.GetArgument<AddCourseTeacherInput>("input")));
        }

        private async Task<Course> AddCourseAsync(AddCourseInput addCourseInput)
        {
            var department = await _departmentService.GetDepartmentById(addCourseInput.DepartmentId);

            if (department == null)
            {
                throw new Exception("The department does not exist");
            }

            return await _courseService.InsertCourse(addCourseInput.Name, addCourseInput.DepartmentId);
        }
        private async Task<CourseStudent> AddCourseStudentAsync(AddCourseStudentInput addCourseStudent)
        {
            var person = await _personService.GetPersonById(addCourseStudent.StudentId, PersonType.Student);

            if (person == null)
            {
                throw new Exception("The person does not exist");
            }

            var schoolPeriodCourse = await _schoolPeriodCourseService.GetSchoolPeriodCoursesById(addCourseStudent.ScholPeriodCourseId);
            if (schoolPeriodCourse == null)
            {
                throw new Exception("The course period does not exist");
            }

            return await _courseStudentService.InsertCourseStudent(addCourseStudent.StudentId, addCourseStudent.ScholPeriodCourseId);
        }
        private async Task<CourseTeacher> AddCourseTeacherAsync(AddCourseTeacherInput addCourseTeacherInput)
        {
            var person = await _personService.GetPersonById(addCourseTeacherInput.TeacherId, PersonType.Teacher);

            if (person == null)
            {
                throw new Exception("The person does not exist");
            }

            var schoolPeriodCourse = await _schoolPeriodCourseService.GetSchoolPeriodCoursesById(addCourseTeacherInput.ScholPeriodCourseId);
            if (schoolPeriodCourse == null)
            {
                throw new Exception("The course period does not exist");
            }

            return await _courseTeacherService.InsertCourseTeacher(addCourseTeacherInput.TeacherId, addCourseTeacherInput.ScholPeriodCourseId);
        }
    }
}
