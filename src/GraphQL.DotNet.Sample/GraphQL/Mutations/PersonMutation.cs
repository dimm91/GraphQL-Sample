using GraphQL.DotNet.Sample.GraphQL.InputTypes;
using GraphQL.DotNet.Sample.GraphQL.Types;
using GraphQL.Sample.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Mutations
{
    internal partial class RootMutation
    {
        public void SetPersonMutations()
        {
            Field<PersonGraphType>(
              "AddPerson",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AddPersonInputType>> { Name = "input" }),
              resolve: c => AddPersonAsync(c.GetArgument<AddPersonInput>("input")));
        }
        private async Task<Person> AddPersonAsync(AddPersonInput addPersonInput)
        {
            var person = await _personService.GetPersonByEmail(addPersonInput.Email);
            if (person != null)
            {
                throw new Exception("A person already exist with the email");
            }

            return await _personService.InsertPerson(addPersonInput.Name, addPersonInput.Lastname, addPersonInput.Email, addPersonInput.PersonType);
        }
    }
}
