using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Schools;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class SchoolMutation
    {
        public record AddSchoolInput(string Name, string CountryCode, string Address);
        public async Task<School> AddSchoolAsync(
            [GraphQLNonNullType] AddSchoolInput input,
            [Service] ISchoolService schoolService)
        {
            return await schoolService.InsertSchool(input.Name, input.Address, input.CountryCode);
        }
    }
}
