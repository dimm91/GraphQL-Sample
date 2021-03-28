using GraphQL.DataLoader;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Courses;
using GraphQL.Sample.Service.Services.CourseStudents;
using GraphQL.Sample.Service.Services.CourseTeachers;
using GraphQL.Sample.Service.Services.Persons;
using GraphQL.Sample.Service.Services.SchoolPeriodCourses;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Types
{
    public class SchoolPeriodCourseGraphType : ObjectGraphType<SchoolPeriodCourse>
    {
        public SchoolPeriodCourseGraphType(IDataLoaderContextAccessor accessor,
            ICourseService courseService,
            ICourseStudentService courseStudentService,
            ICourseTeacherService courseTeacherService,
            IPersonService personService)
        {
            Name = "SchoolPeriodCourse";
            Field(x => x.SchoolPeriodCourseId);
            Field(x => x.SchoolPeriodId);
            Field(x => x.CourseId);
            Field(x => x.Credits);
            Field<ListGraphType<CourseGraphType>>()
                .Name("Courses")
                .Resolve(r => SchoolPeriodCourseResolvers.CoursesByPeriodCourseIds(accessor, r, courseService));

            Field<ListGraphType<PersonGraphType>>()
                .Name("CourseStudents")
                .Resolve(r => SchoolPeriodCourseResolvers.StudentsByPeriodCourseId(accessor, r, courseStudentService, personService));

            Field<ListGraphType<PersonGraphType>>()
                .Name("CourseTeachers")
                .Resolve(r => SchoolPeriodCourseResolvers.TeachersByPeriodCourseId(accessor, r, courseTeacherService, personService));
        }
        private static class SchoolPeriodCourseResolvers
        {
            public static IDataLoaderResult<List<Course>> CoursesByPeriodCourseIds(IDataLoaderContextAccessor accessor, IResolveFieldContext<SchoolPeriodCourse> context, ICourseService courseService)
            {
                var coursesLoader = accessor.Context.GetOrAddBatchLoader<int, List<Course>>("GetCoursesById", async x =>
                {
                    var courses = await courseService.GetCourses(x);
                    return courses.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToList());
                });

                return coursesLoader.LoadAsync(context.Source.CourseId);
            }

            public static IDataLoaderResult<IDataLoaderResult<IEnumerable<Person>>> StudentsByPeriodCourseId(IDataLoaderContextAccessor accessor,
                IResolveFieldContext<SchoolPeriodCourse> context,
                ICourseStudentService courseStudentService
                , IPersonService personService)
            {
                var courseStudentLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, CourseStudent>("GetCourseStudentByPeriodCourse", async x =>
                {
                    var schoolPeriods = await courseStudentService.GetCourseStudentsByPeriodCourseId(x);
                    return schoolPeriods.ToLookup(x => x.SchoolPeriodCourseId, x => x);
                });

                return courseStudentLoader.LoadAsync(context.Source.SchoolPeriodCourseId)
                    .Then(async (courseStudents, _) =>
                {
                    var personLoader = accessor.Context.GetOrAddBatchLoader<int, Person>("GetPersonById", async x =>
                    {
                        var persons = await personService.GetPersons(x);
                        return persons.ToDictionary(p => p.PersonId, p => p);
                    });

                    return personLoader.LoadAsync(courseStudents.Select(cs => cs.StudentId))
                    .Then(resultSet => resultSet.AsEnumerable());
                });
            }


            public static IDataLoaderResult<IDataLoaderResult<IEnumerable<Person>>> TeachersByPeriodCourseId(IDataLoaderContextAccessor accessor,
                IResolveFieldContext<SchoolPeriodCourse> context,
                ICourseTeacherService courseTeacherService
                , IPersonService personService)
            {
                var courseStudentLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, CourseTeacher>("GetCourseTeacherByPeriodCourse", async x =>
                {
                    var schoolPeriods = await courseTeacherService.GetCourseTeachersByPeriodCourseId(x);
                    return schoolPeriods.ToLookup(x => x.SchoolPeriodCourseId, x => x);
                });

                var courseStudentLoaderResult = courseStudentLoader.LoadAsync(context.Source.SchoolPeriodCourseId);

                return courseStudentLoaderResult.Then(async (courseStudents, _) =>
                {
                    var auxLoader = accessor.Context.GetOrAddBatchLoader<int, Person>("GetPersonById", async x =>
                    {
                        var persons = await personService.GetPersons(x);
                        return persons.ToDictionary(p => p.PersonId, p => p);
                    });

                    return auxLoader.LoadAsync(courseStudents.Select(cs => cs.TeacherId))
                    .Then(resultSet => resultSet.AsEnumerable());
                });
            }
        }
    }
}
