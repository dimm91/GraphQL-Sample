using GraphQL.HotChocolate.Sample.GraphQL.DataLoaders;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Persons;
using GreenDonut;
using HotChocolate;
using HotChocolate.DataLoader;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class PersonQuery
    {

        public async Task<IEnumerable<Person>> GetPersonsByType(
            [GraphQLNonNullType] PersonType personType,
            [Service] IPersonService personService,
            CancellationToken cancellationToken)
        {
            return await personService.GetPersonsBytype(personType);
        }
    }
}
