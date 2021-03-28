using GraphQL.Sample.Service.Services.CourseStudents;
using GreenDonut;
using HotChocolate.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.DataLoaders
{
    public class StudenIdsByPeriodCourseIdDataLoader : BatchDataLoader<int, List<int>>
    {
        private readonly ICourseStudentService _courseStudentService;
        public StudenIdsByPeriodCourseIdDataLoader(ICourseStudentService courseStudentService, IBatchScheduler batchScheduler) : base(batchScheduler)
        {
            _courseStudentService = courseStudentService;
        }

        protected override async Task<IReadOnlyDictionary<int, List<int>>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var courseStudents = await _courseStudentService.GetCourseStudentsByPeriodCourseId(keys);
            return courseStudents.GroupBy(cs => cs.SchoolPeriodCourseId)
                .ToDictionary(g => g.Key, g => g.Select(a => a.StudentId).ToList());
        }
    }
}
