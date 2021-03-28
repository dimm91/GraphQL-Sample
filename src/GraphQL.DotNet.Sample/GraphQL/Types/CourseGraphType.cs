using GraphQL.DataLoader;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Departments;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.DotNet.Sample.GraphQL.Types
{
    public class CourseGraphType : ObjectGraphType<Course>
    {
        public CourseGraphType(IDataLoaderContextAccessor accessor, IDepartmentService departmentService)
        {
            Name = "Course";
            Field(x => x.Id);
            Field(x => x.Name);
            Field<DepartmentGraphType>()
            .Name("Department")
            .Resolve(r => CourseResolvers.GetDepartmentsById(accessor, r, departmentService));
        }

        private static class CourseResolvers
        {
            public static IDataLoaderResult<Department> GetDepartmentsById(IDataLoaderContextAccessor accessor, IResolveFieldContext<Course> context, IDepartmentService departmentService)
            {
                var loader = accessor.Context.GetOrAddBatchLoader<int, Department>("GetDepartmentsById", async x =>
                {
                    var departments = await departmentService.GetDepartmentsByIds(x);
                    return departments.ToDictionary(d => d.DepartmentId, g => g);
                });

                return loader.LoadAsync(context.Source.DepartmentId);
            }
        }
    }
}
