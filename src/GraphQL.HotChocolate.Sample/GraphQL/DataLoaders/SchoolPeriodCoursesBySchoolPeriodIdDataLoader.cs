using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.SchoolPeriodCourses;
using HotChocolate.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.DataLoaders
{
    public class SchoolPeriodCoursesBySchoolPeriodIdDataLoader : BatchDataLoader<int, List<SchoolPeriodCourse>>
    {
        private readonly ISchoolPeriodCourseService _schoolPeriodCourseService;
        public SchoolPeriodCoursesBySchoolPeriodIdDataLoader(GreenDonut.IBatchScheduler batchScheduler,
            ISchoolPeriodCourseService schoolPeriodCourseService) : base(batchScheduler)
        {
            _schoolPeriodCourseService = schoolPeriodCourseService;
        }
        protected override async Task<IReadOnlyDictionary<int, List<SchoolPeriodCourse>>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var schoolPeriodCourses = await _schoolPeriodCourseService.GetScholPeriodCoursesBySchoolPeriodIds(keys);

            return schoolPeriodCourses.GroupBy(sdp => sdp.SchoolPeriodId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
