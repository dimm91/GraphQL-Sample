using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.SchoolPeriods
{
    public class SchoolPeriodService : ISchoolPeriodService
    {
        private readonly ISchoolPeriodRepository _schoolperiodrepository;
        public SchoolPeriodService(ISchoolPeriodRepository schoolperiodrepository)
        {
            _schoolperiodrepository = schoolperiodrepository;
        }

        public async Task<IEnumerable<SchoolPeriod>> GetSchoolPeriodsByPeriods(IEnumerable<string> periods)
        {
            return await _schoolperiodrepository.GetListAsync(sp => periods.Any(p => p == sp.Period));
        }

        public async Task<IEnumerable<SchoolPeriod>> GetSchoolPeriodsBySchoolIds(IEnumerable<int> schoolIds)
        {
            return await _schoolperiodrepository.GetListAsync(sp => schoolIds.Any(p => p == sp.SchoolId));
        }
    }
}
