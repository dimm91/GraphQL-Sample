using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.InputTypes
{
    public record AddCourseStudentInput(int StudentId, int ScholPeriodCourseId);

    public class AddCourseStudentInputType : InputObjectGraphType<AddCourseStudentInput>
    {
        public AddCourseStudentInputType()
        {
            Field(x => x.StudentId);
            Field(x => x.ScholPeriodCourseId);
        }
    }
}
