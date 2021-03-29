using GraphQL.DataLoader;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Courses;
using GraphQL.Sample.Service.Services.SchoolPeriodCourses;
using GraphQL.Sample.Service.Services.SchoolPeriods;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Types
{
    public class SchoolPeriodGraphType : ObjectGraphType<SchoolPeriod>
    {
        public SchoolPeriodGraphType(IDataLoaderContextAccessor accessor, ISchoolPeriodCourseService schoolPeriodCourseService)
        {
            Name = "SchoolPeriod";
            Field(x => x.SchoolPeriodId);
            Field(x => x.Period);
            Field(x => x.SchoolId);

            Field<ListGraphType<SchoolPeriodCourseGraphType>>()
                .Name("SchoolPeriodCourses")
                .Description("Courses from an specific period")
                .Resolve(r => SchoolPeriodResolvers.SchoolPeriodCoursesBySchoolId(accessor, r, schoolPeriodCourseService));
        }

        private static class SchoolPeriodResolvers
        {
            public static IDataLoaderResult<List<SchoolPeriodCourse>> SchoolPeriodCoursesBySchoolId(IDataLoaderContextAccessor accessor, IResolveFieldContext<SchoolPeriod> context, ISchoolPeriodCourseService schoolPeriodCourseService)
            {
                var loader = accessor.Context.GetOrAddBatchLoader<int, List<SchoolPeriodCourse>>("GetSchoolPeriodCoursesBySchooPeriodlId", async x =>
                {
                    var schoolPeriods = await schoolPeriodCourseService.GetSchoolPeriodCoursesBySchoolPeriodIds(x);
                    return schoolPeriods.GroupBy(x => x.SchoolPeriodId).ToDictionary(x => x.Key, x => x.ToList());
                });

                return loader.LoadAsync(context.Source.SchoolPeriodId);
            }
        }
    }
}
