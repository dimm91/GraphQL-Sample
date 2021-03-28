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
    public class CourseType : ObjectType<Course>
    {
        protected override void Configure(IObjectTypeDescriptor<Course> descriptor)
        {
            descriptor.Field(x => x.Department)
                .ResolveWith<CourseResolver>(x => x.GetDepartment(default!, default, default));

        }

        private class CourseResolver
        {
            public async Task<Department> GetDepartment(Course course, DepartmentByIdDataLoader departmentByIdDataLoader, CancellationToken cancellationToken)
            {
                return await departmentByIdDataLoader.LoadAsync(course.DepartmentId, cancellationToken);
            }
        }
    }
}
