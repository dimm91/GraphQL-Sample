using GraphQL.Sample.Service.Services.CourseTeachers;
using GreenDonut;
using HotChocolate.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.DataLoaders
{
    public class TeacherIdsByPeriodCourseIdDataLoader : BatchDataLoader<int, List<int>>
    {
        private readonly ICourseTeacherService _courseTeacherService;
        public TeacherIdsByPeriodCourseIdDataLoader(ICourseTeacherService courseTeacherService, IBatchScheduler batchScheduler) : base(batchScheduler)
        {
            _courseTeacherService = courseTeacherService;
        }

        protected override async Task<IReadOnlyDictionary<int, List<int>>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var courseStudents = await _courseTeacherService.GetCourseTeachersByPeriodCourseId(keys);
            return courseStudents.GroupBy(cs => cs.SchoolPeriodCourseId)
                .ToDictionary(g => g.Key, g => g.Select(a => a.TeacherId).ToList());
        }
    }
}
