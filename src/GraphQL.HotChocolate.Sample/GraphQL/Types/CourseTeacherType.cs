using GraphQL.HotChocolate.Sample.GraphQL.DataLoaders;
using GraphQL.Sample.Domain.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Types
{
    public class CourseTeacherType : ObjectType<CourseTeacher>
    {
        protected override void Configure(IObjectTypeDescriptor<CourseTeacher> descriptor)
        {
            descriptor.Field(x => x.SchoolPeriodCourse).Ignore();
            descriptor
                .Field(x => x.Teacher)
                .ResolveWith<CourseTeacherResolver>(x => x.GetTeacher(default!, default, default));
        }

        private class CourseTeacherResolver
        {
            public async Task<Person> GetTeacher(CourseTeacher courseTeacher, PersonByIdDataLoader departmentByIdDataLoader, CancellationToken cancellationToken)
            {
                return await departmentByIdDataLoader.LoadAsync(courseTeacher.TeacherId, cancellationToken);
            }
        }
    }
}
