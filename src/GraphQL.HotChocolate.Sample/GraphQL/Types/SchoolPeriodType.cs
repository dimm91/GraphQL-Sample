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
    public class SchoolPeriodType : ObjectType<SchoolPeriod>
    {
        protected override void Configure(IObjectTypeDescriptor<SchoolPeriod> descriptor)
        {
            descriptor
                .Field(x => x.SchoolPeriodCourses)
                .Type<ListType<SchoolPeriodCourseType>>()
                .ResolveWith<SchoolPeriodResolvers>(x => x.GetPeriodCourses(default!, default, default));
        }
        private class SchoolPeriodResolvers
        {
            public async Task<IEnumerable<SchoolPeriodCourse>> GetPeriodCourses(SchoolPeriod schoolPeriod,
                SchoolPeriodCoursesBySchoolPeriodIdDataLoader schoolPeriodCoursesBySchoolPeriodIdDataLoader,
                CancellationToken cancellationToken)
            {
                var schoolPeriodCourses = await schoolPeriodCoursesBySchoolPeriodIdDataLoader.LoadAsync(schoolPeriod.SchoolPeriodId, cancellationToken);
                return schoolPeriodCourses ?? default;
            }
        }
    }
}
