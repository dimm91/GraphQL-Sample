using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.InputTypes
{
    public record AddSchoolInput(string Name, string Address, string CountryCode);

    /// <summary>
    /// Remember: The 'AddSchoolInputType' the model exposed to the outside
    /// While the 'AddSchoolInput' is the model you can use in the code. 
    /// Since internally this will the values comming from 'AddSchoolInputType' will be parsed to 'AddSchoolInput'
    /// </summary>
    public class AddSchoolInputType : InputObjectGraphType<AddSchoolInput>
    {
        public AddSchoolInputType()
        {
            Name = "AddSchoolInput";
            Field(x => x.Name);
            Field(x => x.Address);
            Field(x => x.CountryCode);
        }
    }
}
