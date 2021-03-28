using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.SchoolPeriods;
using HotChocolate.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.DataLoaders
{
    public class PeriodsBySchoolIdDataLoader : BatchDataLoader<int, List<SchoolPeriod>>
    {
        private readonly ISchoolPeriodService _schoolPeriodService;
        public PeriodsBySchoolIdDataLoader(GreenDonut.IBatchScheduler batchScheduler,
            ISchoolPeriodService schoolPeriodService) : base(batchScheduler)
        {
            _schoolPeriodService = schoolPeriodService;
        }
        protected override async Task<IReadOnlyDictionary<int, List<SchoolPeriod>>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var schoolPeriods = await _schoolPeriodService.GetSchoolPeriodsBySchoolIds(keys);

            return schoolPeriods.GroupBy(d => d.SchoolId)
                .ToDictionary(d => d.Key, g => g.ToList());
        }
    }
}
