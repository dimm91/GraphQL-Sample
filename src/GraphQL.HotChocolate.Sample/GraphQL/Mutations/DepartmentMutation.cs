using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.Sample.Service.Services.Persons;
using GraphQL.Sample.Service.Services.Schools;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class DepartmentMutation
    {
        public record AddDepartmentInput(string Name, int SchoolId, int AdministratorId);
        public async Task<Department> AddDepartmentAsync(
         [GraphQLNonNullType] AddDepartmentInput input,
         [Service] ISchoolService schoolService,
         [Service] IPersonService personService,
         [Service] IDepartmentService departmentService)
        {
            var school = await schoolService.GetSchoolById(input.SchoolId);
            if (school == null)
            {
                throw new ArgumentNullException("The school does not exist");
            }

            var administrator = await personService.GetPersonById(input.AdministratorId, PersonType.Administrator);
            if (administrator == null)
            {
                throw new ArgumentNullException("The adminastrator does not exist or is not an administrator");
            }

            return await departmentService.InsertDepartment(input.Name, input.SchoolId, input.AdministratorId);
        }
    }
}
