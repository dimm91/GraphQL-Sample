using GraphQL.Sample.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Types
{
    public class PersonGraphType : ObjectGraphType<Person>
    {
        public PersonGraphType()
        {
            Field(p => p.PersonId);
            Field(p => p.Name);
            Field(p => p.Lastname);
            Field(p => p.Email);
            Field<PersonTypeEnumGraphType>()
                .Name("PersonType");

        }
    }
}
