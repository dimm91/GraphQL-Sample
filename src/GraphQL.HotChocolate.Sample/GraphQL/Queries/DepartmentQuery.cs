using GraphQL.HotChocolate.Sample.GraphQL.DataLoaders;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Departments;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Queries
{

    [ExtendObjectType("Query")]
    public class DepartmentQuery
    {
        public async Task<IEnumerable<Department>> GetDepartmentsBySchoolIds(
            [GraphQLNonNullType] int schoolId,
            DepartmentBySchoolIdDataLoader departmentBySchoolIdDataLoader,
            CancellationToken cancellationToken)
        {
            return await departmentBySchoolIdDataLoader.LoadAsync(schoolId, cancellationToken);
        }
        public async Task<IEnumerable<Department>> GetDepartmentsByIds(
            [GraphQLNonNullType] int[] departmentIds,
            DepartmentByIdDataLoader departmentByIdDataLoader,
            CancellationToken cancellationToken)
        {
            return await departmentByIdDataLoader.LoadAsync(departmentIds, cancellationToken);
        }
    }
}
