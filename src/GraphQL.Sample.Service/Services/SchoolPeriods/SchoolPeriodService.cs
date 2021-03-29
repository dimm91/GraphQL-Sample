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
        private readonly ISchoolPeriodRepository _schoolPeriodRepository;
        public SchoolPeriodService(ISchoolPeriodRepository schoolperiodrepository)
        {
            _schoolPeriodRepository = schoolperiodrepository;
        }

        public async Task<SchoolPeriod> GetSchoolPeriodById(int schoolPeriodId)
        {
            return await _schoolPeriodRepository.GetElementAsync(sp => sp.SchoolPeriodId == schoolPeriodId);
        }

        public async Task<IEnumerable<SchoolPeriod>> GetSchoolPeriodsByPeriods(IEnumerable<string> periods)
        {
            return await _schoolPeriodRepository.GetListAsync(sp => periods.Any(p => p == sp.Period));
        }

        public async Task<IEnumerable<SchoolPeriod>> GetSchoolPeriodsBySchoolIds(IEnumerable<int> schoolIds)
        {
            return await _schoolPeriodRepository.GetListAsync(sp => schoolIds.Any(p => p == sp.SchoolId));
        }

        public async Task<SchoolPeriod> InsertSchoolPeriod(int schoolId, string period)
        {
            var schoolPeriod = new SchoolPeriod(schoolId, period);
            await _schoolPeriodRepository.CreateAsync(schoolPeriod);
            return schoolPeriod;
        }
    }
}