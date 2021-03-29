using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.InputTypes
{
    public record AddDepartmentInput(string Name, int SchoolId, int AdministratorId);

    public class AddDepartmentInputType : InputObjectGraphType<AddDepartmentInput>
    {
        public AddDepartmentInputType()
        {
            Field(x => x.Name);
            Field(x => x.AdministratorId);
            Field(x => x.SchoolId);
        }
    }
}
