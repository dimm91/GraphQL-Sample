using GraphQL.DotNet.Sample.GraphQL.Types;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Queries
{
    internal partial class RootQuery
    {
        public void SetDepartmentQuery()
        {
            Field<ListGraphType<DepartmentGraphType>>("DepartmentsBySchoolIds",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<IntGraphType>>> { Name = "schoolIds", Description = "id of the school" }
                ),
                resolve: context => GetDepartmentsBySchoolIds(context.GetArgument<int[]>("schoolIds"), _departmentService));


            Field<ListGraphType<DepartmentGraphType>>("DepartmentsByIds",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<IntGraphType>>> { Name = "departmentIds", Description = "id of the department" }
                ),
                resolve: context => GetDepartmentsByDepartmentIds(context.GetArgument<int[]>("departmentIds"), _departmentService));

        }
        private async Task<IEnumerable<Department>> GetDepartmentsBySchoolIds(int[] schoolIds, IDepartmentService departmentService)
        {
            return await departmentService.GetDepartmentsBySchoolId(schoolIds);
        }
        private async Task<IEnumerable<Department>> GetDepartmentsByDepartmentIds(int[] departmentIds, IDepartmentService departmentService)
        {
            return await departmentService.GetDepartmentsByIds(departmentIds);
        }
    }
}
