using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.InputTypes
{
    public record AddSchoolPeriodCourseInput(int SchoolPeriodId, int CourseId, int Credits);
    public class AddSchoolPeriodCourseInputType : InputObjectGraphType<AddSchoolPeriodCourseInput>
    {
        public AddSchoolPeriodCourseInputType()
        {
            Field(x => x.SchoolPeriodId);
            Field(x => x.CourseId);
            Field(x => x.Credits);
        }
    }
}
