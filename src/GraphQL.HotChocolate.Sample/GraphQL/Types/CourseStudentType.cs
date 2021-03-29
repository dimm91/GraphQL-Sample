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
    public class CourseStudentType : ObjectType<CourseStudent>
    {
        protected override void Configure(IObjectTypeDescriptor<CourseStudent> descriptor)
        {
            descriptor.Field(x => x.SchoolPeriodCourse).Ignore();
            descriptor
                .Field(x => x.Student)
                .ResolveWith<CourseStudentResolver>(x => x.GetTeacher(default!, default, default));
        }

        private class CourseStudentResolver
        {
            public async Task<Person> GetTeacher(CourseStudent courseStudent, PersonByIdDataLoader departmentByIdDataLoader, CancellationToken cancellationToken)
            {
                return await departmentByIdDataLoader.LoadAsync(courseStudent.StudentId, cancellationToken);
            }
        }
    }
}
