using GraphQL.DotNet.Sample.GraphQL.InputTypes;
using GraphQL.DotNet.Sample.GraphQL.Types;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Mutations
{
    internal partial class RootMutation
    {
        public void SetDepartmentMutations()
        {
            Field<DepartmentGraphType>(
              "AddDepartment",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AddDepartmentInputType>> { Name = "input" }),
              resolve: c => AddDepartmentAsync(c.GetArgument<AddDepartmentInput>("input")));
        }
        private async Task<Department> AddDepartmentAsync(AddDepartmentInput addDepartmentInput)
        {
            var school = await _schoolService.GetSchoolById(addDepartmentInput.SchoolId);
            if (school == null)
            {
                throw new ArgumentNullException("The school does not exist");
            }

            var administrator = await _personService.GetPersonById(addDepartmentInput.AdministratorId, PersonType.Administrator);
            if (administrator == null)
            {
                throw new ArgumentNullException("The administrator does not exist or is not an administrator");
            }

            return await _departmentService.InsertDepartment(addDepartmentInput.Name, addDepartmentInput.SchoolId, addDepartmentInput.AdministratorId);
        }
    }
}

