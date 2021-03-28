using GraphQL.DotNet.Sample.GraphQL.Types;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Courses;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Queries
{
    internal partial class RootQuery
    {
        public void SetCourseQuery()
        {
            Field<ListGraphType<CourseGraphType>>(
              "GetCoursesByIds",
              arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<IntGraphType>>> { Name = "courseIds", Description = "Type of the person " }
                ),
              resolve: context => GetCoursesByIds(_courseService, context.GetArgument<List<int>>("courseIds")));
        }

        private async Task<IEnumerable<Course>> GetCoursesByIds(ICourseService courseService, List<int> courseIds)
        {
            return await courseService.GetCourses(courseIds);
        }
    }
}
