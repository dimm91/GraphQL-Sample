using GraphQL.DataLoader;
using GraphQL.Resolvers;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.Sample.Service.Services.SchoolPeriods;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Types
{
    public class SchoolGraphType : ObjectGraphType<School>
    {
        public SchoolGraphType(IDataLoaderContextAccessor accessor, IDepartmentService departmentService, ISchoolPeriodService schoolPeriodService)
        {
            Name = "School";
            Description = "This is the school entity";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("School Id");
            Field(x => x.Name).Description("Schools Name");
            Field(x => x.CountryCode).Description("Country code of the school");
            Field(x => x.Address).Description("Address of the school");
            Field<ListGraphType<DepartmentGraphType>>()
                .Name("Departments")
                .Description("Department from the school")
                .Resolve(c => SchoolResolvers.DepartmentsBySchoolId(accessor, c, departmentService));
            Field<ListGraphType<SchoolPeriodGraphType>>()
                .Name("SchoolPeriods")
                .Description("Periods per school")
                .Resolve(c => SchoolResolvers.SchoolPeriodsBySchoolId(accessor, c, schoolPeriodService));
        }


        private static class SchoolResolvers
        {
            public static IDataLoaderResult<List<Department>> DepartmentsBySchoolId(IDataLoaderContextAccessor accessor, IResolveFieldContext<School> context, IDepartmentService departmentService)
            {
                // Get or add a batch loader with the key "GetDepartmentsById"
                // The loader will call GetDepartmentsBySchoolId for each batch of keys
                var loader = accessor.Context.GetOrAddBatchLoader<int, List<Department>>("GetDepartmentsBySchoolId", async x =>
                {
                    var departments = await departmentService.GetDepartmentsBySchoolId(x);
                    return departments.GroupBy(d => d.SchoolId).ToDictionary(d => d.Key, g => g.ToList());
                });

                //  The execution strategy will trigger the data loader to fetch the data via GetDepartmentsBySchoolId() at the
                //  appropriate time, and the field will be resolved with an instance of Department once GetDepartmentsBySchoolId()
                //  returns with the batched results
                return loader.LoadAsync(context.Source.Id);
            }


            public static IDataLoaderResult<List<SchoolPeriod>> SchoolPeriodsBySchoolId(IDataLoaderContextAccessor accessor, IResolveFieldContext<School> context, ISchoolPeriodService schoolPeriodService)
            {
                var loader = accessor.Context.GetOrAddBatchLoader<int, List<SchoolPeriod>>("GetSchoolPeriodsBySchoolId", async x =>
                {
                    var schoolPeriods = await schoolPeriodService.GetSchoolPeriodsBySchoolIds(x);
                    return schoolPeriods.GroupBy(x => x.SchoolId).ToDictionary(x => x.Key, x => x.ToList());
                });

                return loader.LoadAsync(context.Source.Id);
            }
        }
    }
}