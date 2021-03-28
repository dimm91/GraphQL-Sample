using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Courses;
using GreenDonut;
using HotChocolate.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.DataLoaders
{
    public class CourseByIdDataLoader : BatchDataLoader<int, Course>
    {
        private readonly ICourseService _courseService;
        public CourseByIdDataLoader(ICourseService courseService, IBatchScheduler batchScheduler) : base(batchScheduler)
        {
            _courseService = courseService;
        }

        protected override async Task<IReadOnlyDictionary<int, Course>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var courses = await _courseService.GetCourses(keys);
            return courses.ToDictionary(c => c.Id, c => c);
        }
    }
}
