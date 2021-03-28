using GraphQL.HotChocolate.Sample.GraphQL.DataLoaders;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Courses;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.Sample.Service.Services.SchoolPeriodCourses;
using GraphQL.Sample.Service.Services.SchoolPeriods;
using GraphQL.Sample.Service.Services.Schools;
using HotChocolate;
using HotChocolate.DataLoader;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Types
{

    public class SchoolType : ObjectType<School>
    {
        protected override void Configure(IObjectTypeDescriptor<School> descriptor)
        {
            descriptor.
                Field(x => x.Name);

            descriptor.Field(x => x.Departments)
                .ResolveWith<SchoolResolvers>(a => a.GetDepartments(default!, default, default));

            descriptor.Field(x => x.SchoolPeriods)
                .Type<ListType<SchoolPeriodType>>()
                .ResolveWith<SchoolResolvers>(a => a.GetPeriods(default!, default, default));
        }

        private class SchoolResolvers
        {
            public async Task<IEnumerable<Department>> GetDepartments(School school, DepartmentBySchoolIdDataLoader departmentByIdDataLoader, CancellationToken cancellationToken)
            {
                var departments = await departmentByIdDataLoader.LoadAsync(school.Id, cancellationToken);
                return departments ?? default;
            }

            public async Task<IEnumerable<SchoolPeriod>> GetPeriods(School school, PeriodsBySchoolIdDataLoader schoolPeriodService, CancellationToken cancellationToken)
            {
                return await schoolPeriodService.LoadAsync(school.Id, cancellationToken);
            }
        }
    }
}
