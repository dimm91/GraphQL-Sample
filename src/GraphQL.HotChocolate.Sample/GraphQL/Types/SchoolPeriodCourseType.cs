using GraphQL.HotChocolate.Sample.GraphQL.DataLoaders;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.CourseStudents;
using GreenDonut;
using HotChocolate;
using HotChocolate.DataLoader;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Types
{
    public class SchoolPeriodCourseType : ObjectType<SchoolPeriodCourse>
    {
        protected override void Configure(IObjectTypeDescriptor<SchoolPeriodCourse> descriptor)
        {
            descriptor
                .Field(x => x.Course)
                .ResolveWith<SchoolPeriodCourseResolvers>(x => x.GetCourses(default!, default, default));

            descriptor
                .Field(x => x.CourseStudents)
                .ResolveWith<SchoolPeriodCourseResolvers>(x => x.GetStudents(default!, default, default, default));

            descriptor
                .Field(x => x.CourseTeachers)
                .ResolveWith<SchoolPeriodCourseResolvers>(x => x.GetTeachers(default!, default, default, default));
        }

        private class SchoolPeriodCourseResolvers
        {
            public async Task<Course> GetCourses(SchoolPeriodCourse schoolPeriodCourse, CourseByIdDataLoader courseByIdDataLoader, CancellationToken cancellationToken)
            {
                var courses = await courseByIdDataLoader.LoadAsync(schoolPeriodCourse.CourseId, cancellationToken);
                return courses ?? default;
            }

            public async Task<IEnumerable<Person>> GetStudents(SchoolPeriodCourse schoolPeriodCourse, StudenIdsByPeriodCourseIdDataLoader studenIdsByPeriodCourseIdDataLoader,
                PersonByIdDataLoader personByIdDataLoader, CancellationToken cancellationToken)
            {
                var studentsIds = await studenIdsByPeriodCourseIdDataLoader.LoadAsync(schoolPeriodCourse.SchoolPeriodCourseId);
                if (studentsIds == null)
                {
                    return default;
                }

                var students = await personByIdDataLoader.LoadAsync(studentsIds, cancellationToken);
                return students ?? default;
            }

            public async Task<IEnumerable<Person>> GetTeachers(SchoolPeriodCourse schoolPeriodCourse, TeacherIdsByPeriodCourseIdDataLoader teacherIdsByPeriodCourseIdDataLoader,
                PersonByIdDataLoader personByIdDataLoader, CancellationToken cancellationToken)
            {
                var studentsIds = await teacherIdsByPeriodCourseIdDataLoader.LoadAsync(schoolPeriodCourse.SchoolPeriodCourseId);
                if (studentsIds == null)
                {
                    return default;
                }

                var students = await personByIdDataLoader.LoadAsync(studentsIds, cancellationToken);
                return students ?? default;
            }

        }
    }
}
