using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Persons;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class PersonMutation
    {
        public record AddPersonInput(string Name, string Lastname, string Email, PersonType PersonType);
        public async Task<Person> AddPersonAsync(
         [GraphQLNonNullType] AddPersonInput input,
         [Service] IPersonService personService)
        {
            var person = await personService.GetPersonByEmail(input.Email);
            if (person != null)
            {
                throw new Exception("A person already exist with the email");
            }

            return await personService.InsertPerson(input.Name, input.Lastname, input.Email, input.PersonType);
        }
    }
}
