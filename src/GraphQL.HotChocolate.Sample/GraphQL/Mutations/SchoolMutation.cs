using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.SchoolPeriodCourses;
using GraphQL.Sample.Service.Services.SchoolPeriods;
using GraphQL.Sample.Service.Services.Schools;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class SchoolMutation
    {
        public record AddSchoolInput(string Name, string CountryCode, string Address);
        public record AddSchoolPeriodInput(int SchoolId, string Period);
        public record AddSchoolPeriodCourseInput(int SchoolPeriodId, int CourseId, int Credits);
        public async Task<School> AddSchoolAsync(
            [GraphQLNonNullType] AddSchoolInput input,
            [Service] ISchoolService schoolService)
        {
            return await schoolService.InsertSchool(input.Name, input.Address, input.CountryCode);
        }
        public async Task<SchoolPeriod> AddSchoolPeriodAsync(
            [GraphQLNonNullType] AddSchoolPeriodInput input,
            [Service] ISchoolPeriodService schoolPeriodService,
            [Service] ISchoolService schoolService)
        {
            var school = await schoolService.GetSchoolById(input.SchoolId);
            if (school == null)
            {
                throw new Exception("There is no school with that id");
            }

            return await schoolPeriodService.InsertSchoolPeriod(input.SchoolId, input.Period);
        }
        public async Task<SchoolPeriodCourse> AddSchoolPeriodCourseAsync(
         [GraphQLNonNullType] AddSchoolPeriodCourseInput input,
         [Service] ISchoolPeriodService schoolPeriodService,
         [Service] ISchoolPeriodCourseService schoolPeriodCourseService)
        {
            var schoolPeriod = await schoolPeriodService.GetSchoolPeriodById(input.SchoolPeriodId);
            if (schoolPeriod == null)
            {
                throw new Exception("There is no 'schoolPeriod' with that id");
            }

            return await schoolPeriodCourseService.InsertSchoolPeriodCourse(input.SchoolPeriodId, input.CourseId, input.Credits);
        }
    }
}
