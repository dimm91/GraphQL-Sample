﻿using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.SchoolPeriods
{
    public interface ISchoolPeriodService
    {
        Task<IEnumerable<SchoolPeriod>> GetSchoolPeriodsBySchoolIds(IEnumerable<int> schoolIds);
        Task<IEnumerable<SchoolPeriod>> GetSchoolPeriodsByPeriods(IEnumerable<string> periods);
    }
}