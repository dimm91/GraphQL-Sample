using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.InputTypes
{
    public record AddSchoolPeriodInput(int SchoolId, string Period);
    public class AddSchoolPeriodInputType : InputObjectGraphType<AddSchoolPeriodInput>
    {
        public AddSchoolPeriodInputType()
        {
            Field(x => x.SchoolId);
            Field(x => x.Period);
        }
    }
}
