using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.InputTypes
{
    public record AddCourseTeacherInput(int TeacherId, int ScholPeriodCourseId);
    public class AddCourseTeacherInputType : InputObjectGraphType<AddCourseTeacherInput>
    {
        public AddCourseTeacherInputType()
        {
            Field(x => x.TeacherId);
            Field(x => x.ScholPeriodCourseId);
        }
    }
}
