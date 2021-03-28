using GraphQL.DotNet.Sample.GraphQL.Types;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Schools;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Queries
{
    internal partial class RootQuery
    {
        public void SetSchoolQuery()
        {
            Field<ListGraphType<SchoolGraphType>>(
              "Schools",
              resolve: context => GetSchools(_schoolService));
        }
        private async Task<IEnumerable<School>> GetSchools(ISchoolService schoolService)
        {
            return await schoolService.GetSchools();
        }
    }
}
