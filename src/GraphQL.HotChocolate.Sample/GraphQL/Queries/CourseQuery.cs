using GraphQL.HotChocolate.Sample.GraphQL.DataLoaders;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Courses;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class CourseQuery
    {
        public async Task<IEnumerable<Course>> GetCourses([GraphQLNonNullType] List<int> courseIds, CourseByIdDataLoader courseByIdDataLoader, CancellationToken cancellationToken)
        {
            return await courseByIdDataLoader.LoadAsync(courseIds, cancellationToken);
        }
    }
}
