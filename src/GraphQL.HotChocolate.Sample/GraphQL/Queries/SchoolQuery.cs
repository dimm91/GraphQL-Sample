using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Schools;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Queries
{

    [ExtendObjectType("Query")]
    public class SchoolQuery
    {
        public async Task<IEnumerable<School>> GetSchools([Service] ISchoolService schoolService)
        {
            return await schoolService.GetSchools();
        }
    }
}
