using GraphQL.DotNet.Sample.GraphQL.Types;
using GraphQL.Sample.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.InputTypes
{
    public record AddPersonInput(string Name, string Lastname, string Email, PersonType PersonType);
    public class AddPersonInputType : InputObjectGraphType<AddPersonInput>
    {
        public AddPersonInputType()
        {
            Field(x => x.Name);
            Field(x => x.Lastname);
            Field(x => x.Email);
            Field<PersonTypeEnumGraphType>()
                .Name("PersonType");
        }
    }
}
