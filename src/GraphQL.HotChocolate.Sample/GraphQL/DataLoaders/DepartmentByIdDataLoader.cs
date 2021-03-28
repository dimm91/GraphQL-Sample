using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Departments;
using HotChocolate.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.DataLoaders
{

    public class DepartmentByIdDataLoader : BatchDataLoader<int, Department>
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentByIdDataLoader(GreenDonut.IBatchScheduler batchScheduler,
            IDepartmentService departmentService) : base(batchScheduler)
        {
            _departmentService = departmentService;
        }
        protected override async Task<IReadOnlyDictionary<int, Department>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var departments = await _departmentService.GetDepartmentsBySchoolId(keys);
            return departments.ToDictionary(d => d.DepartmentId, g => g);
        }
    }
}
