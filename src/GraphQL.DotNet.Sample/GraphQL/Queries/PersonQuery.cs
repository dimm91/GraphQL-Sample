using GraphQL.DotNet.Sample.GraphQL.Types;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Persons;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Queries
{
    internal partial class RootQuery
    {
        public void SetPersonQuery()
        {
            Field<ListGraphType<PersonGraphType>>(
              "PersonsByType",
              arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PersonTypeEnumGraphType>> { Name = "personType", Description = "Type of the person " }
                ),
              resolve: context => GetPersonsByType(_personService, context.GetArgument<PersonType>("personType")));
        }

        private async Task<IEnumerable<Person>> GetPersonsByType(IPersonService personService, PersonType personType)
        {
            return await personService.GetPersonsBytype(personType);
        }
    }
}
