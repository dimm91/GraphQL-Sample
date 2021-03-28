using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Repositories
{
    public class SchoolPeriodRepository: BaseRepository<SchoolPeriod>, ISchoolPeriodRepository
    {
        public SchoolPeriodRepository(IDbContextFactory<SchoolDbContext> dbContextFactory) : base(dbContextFactory)
        {

        }
    }
}
