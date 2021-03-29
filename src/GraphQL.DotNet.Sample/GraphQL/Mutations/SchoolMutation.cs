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
    partial class RootMutation
    {
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
        public record AddSchoolInput(string Name, string Address, string CountryCode);
        public void SetSchoolMutations()
        {
            Field<SchoolGraphType>(
              "AddSchool",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AddSchoolInputType>> { Name = "input" }),
              resolve: c => AddSchoolAsync(_schoolService, c.GetArgument<AddSchoolInput>("input")));
        }
        private async Task<School> AddSchoolAsync(ISchoolService schoolService, AddSchoolInput addSchoolInput)
        {
            return await schoolService.InsertSchool(addSchoolInput.Name, addSchoolInput.CountryCode, addSchoolInput.Address);
        }
    }
}
