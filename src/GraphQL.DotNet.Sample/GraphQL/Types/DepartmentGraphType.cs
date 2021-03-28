using GraphQL.DataLoader;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.Sample.Service.Services.Persons;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Types
{
    public class DepartmentGraphType : ObjectGraphType<Department>
    {
        public DepartmentGraphType(IDataLoaderContextAccessor accessor, IPersonService personService)
        {
            Name = "Department";
            Description = "This is the department entity";
            Field(x => x.DepartmentId, type: typeof(IdGraphType)).Description("Department Id");
            Field(x => x.Name).Description("Department Name");
            Field(x => x.SchoolId).Description("School Id from the department");
            Field<PersonGraphType>()
                .Name("Administrator")
                .Resolve(r => DepartmentResolvers.GetAdministatorById(accessor, r, personService));

        }

        private static class DepartmentResolvers
        {
            public static IDataLoaderResult<Person> GetAdministatorById(IDataLoaderContextAccessor accessor, IResolveFieldContext<Department> context, IPersonService personService)
            {
                var loader = accessor.Context.GetOrAddBatchLoader<int, Person>("GetAdministratorById", async x =>
                {
                    var administrators = await personService.GetPersons(x);
                    return administrators.ToDictionary(d => d.PersonId, g => g);
                });

                return loader.LoadAsync(context.Source.AdministratorId);
            }
        }
    }
}
