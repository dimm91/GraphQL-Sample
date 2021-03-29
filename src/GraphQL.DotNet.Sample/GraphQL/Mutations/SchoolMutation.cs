using GraphQL.DotNet.Sample.GraphQL.InputTypes;
using GraphQL.DotNet.Sample.GraphQL.Types;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Schools;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Mutations
{
    internal partial class RootMutation
    {
        public void SetSchoolMutations()
        {
            Field<SchoolGraphType>(
              "AddSchool", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AddSchoolInputType>> { Name = "input" }),
              resolve: c => AddSchoolAsync(c.GetArgument<AddSchoolInput>("input")));

            Field<SchoolPeriodGraphType>(
              "AddSchoolPeriod", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AddSchoolPeriodInputType>> { Name = "input" }),
              resolve: c => AddSchoolPeriodAsync(c.GetArgument<AddSchoolPeriodInput>("input")));

            Field<SchoolPeriodCourseGraphType>(
              "AddSchoolPeriodCourse", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AddSchoolPeriodCourseInputType>> { Name = "input" }),
              resolve: c => AddSchoolPeriodCourseAsync(c.GetArgument<AddSchoolPeriodCourseInput>("input")));
        }
        private async Task<School> AddSchoolAsync(AddSchoolInput addSchoolInput)
        {
            return await _schoolService.InsertSchool(addSchoolInput.Name, addSchoolInput.CountryCode, addSchoolInput.Address);
        }
        private async Task<SchoolPeriod> AddSchoolPeriodAsync(AddSchoolPeriodInput addSchoolInput)
        {
            var school = await _schoolService.GetSchoolById(addSchoolInput.SchoolId);
            if (school == null)
            {
                throw new Exception("There is no school with that id");
            }

            return await _schoolPeriodService.InsertSchoolPeriod(addSchoolInput.SchoolId, addSchoolInput.Period);
        }
        private async Task<SchoolPeriodCourse> AddSchoolPeriodCourseAsync(AddSchoolPeriodCourseInput addSchoolInput)
        {
            var schoolPeriod = await _schoolPeriodService.GetSchoolPeriodById(addSchoolInput.SchoolPeriodId);
            if (schoolPeriod == null)
            {
                throw new Exception("There is no 'schoolPeriod' with that id");
            }
            
            return await _schoolPeriodCourseService.InsertSchoolPeriodCourse(addSchoolInput.SchoolPeriodId, addSchoolInput.CourseId, addSchoolInput.Credits);
        }
    }
}
