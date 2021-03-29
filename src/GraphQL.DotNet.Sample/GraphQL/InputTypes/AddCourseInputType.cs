using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.InputTypes
{
    public record AddCourseInput(string Name, int DepartmentId);
    public class AddCourseInputType : InputObjectGraphType<AddCourseInput>
    {
        public AddCourseInputType()
        {
            Field(x => x.Name);
            Field(x => x.DepartmentId);
        }
    }
}
