using GraphQL.DataLoader;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.CourseStudents;
using GraphQL.Sample.Service.Services.CourseTeachers;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Types
{
    public class PersonGraphType : ObjectGraphType<Person>
    {
        public PersonGraphType(IDataLoaderContextAccessor accessor, ICourseStudentService courseStudentService, ICourseTeacherService courseTeacherService)
        {
            Field(p => p.PersonId);
            Field(p => p.Name);
            Field(p => p.Lastname);
            Field(p => p.Email);
            Field<PersonTypeEnumGraphType>()
                .Name("PersonType");
            Field<ListGraphType<CourseStudentGraphType>>()
                .Name("CourseStudents")
                .Resolve(c => PersonResolvers.GetCourseStudentsById(accessor, c, courseStudentService));

            Field<ListGraphType<CourseTeacherGraphType>>()
                .Name("CourseTeachers")
                .Resolve(c => PersonResolvers.GetCourseTeachersById(accessor, c, courseTeacherService));
        }

        private static class PersonResolvers
        {
            public static IDataLoaderResult<List<CourseStudent>> GetCourseStudentsById(IDataLoaderContextAccessor accessor, IResolveFieldContext<Person> context, ICourseStudentService courseStudentService)
            {
                var loader = accessor.Context.GetOrAddBatchLoader<int, List<CourseStudent>>("GetCourseStudentsByPersonId", async x =>
                {
                    var courseStudents = await courseStudentService.GetCourseStudentsByStudentId(x);
                    return courseStudents.GroupBy(cs => cs.StudentId).ToDictionary(d => d.Key, g => g.ToList());
                });

                return loader.LoadAsync(context.Source.PersonId);
            }

            public static IDataLoaderResult<List<CourseTeacher>> GetCourseTeachersById(IDataLoaderContextAccessor accessor, IResolveFieldContext<Person> context, ICourseTeacherService courseTeacherService)
            {
                var loader = accessor.Context.GetOrAddBatchLoader<int, List<CourseTeacher>>("GetCourseTeachersByPersonId", async x =>
                {
                    var courseTeachers = await courseTeacherService.GetCourseTeachersByTeacherIds(x);
                    return courseTeachers.GroupBy(cs => cs.TeacherId).ToDictionary(d => d.Key, g => g.ToList());
                });

                return loader.LoadAsync(context.Source.PersonId);
            }
        }
    }
}
