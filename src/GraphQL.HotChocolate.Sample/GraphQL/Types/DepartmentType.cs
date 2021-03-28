using GraphQL.HotChocolate.Sample.GraphQL.DataLoaders;
using GraphQL.Sample.Domain.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Types
{
    public class DepartmentType : ObjectType<Department>
    {
        protected override void Configure(IObjectTypeDescriptor<Department> descriptor)
        {
            descriptor.
                Field(d => d.Administrator)
                .ResolveWith<DepartmentResolvers>(x => x.GetDepartmentAdministrator(default!, default, default));
        }

        private class DepartmentResolvers
        {
            public async Task<Person> GetDepartmentAdministrator(Department department, PersonByIdDataLoader persoByIdDataLoader, CancellationToken cancellationToken)
            {
                return await persoByIdDataLoader.LoadAsync(department.AdministratorId, cancellationToken);
            }
        }
    }
}
