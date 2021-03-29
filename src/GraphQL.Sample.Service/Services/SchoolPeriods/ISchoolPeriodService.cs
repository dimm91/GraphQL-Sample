using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.SchoolPeriods
{
    public interface ISchoolPeriodService
    {
        Task<IEnumerable<SchoolPeriod>> GetSchoolPeriodsBySchoolIds(IEnumerable<int> schoolIds);
        Task<SchoolPeriod> GetSchoolPeriodById(int schoolPeriodId);
        Task<IEnumerable<SchoolPeriod>> GetSchoolPeriodsByPeriods(IEnumerable<string> periods);
        Task<SchoolPeriod> InsertSchoolPeriod(int schoolId, string period);
    }
}
