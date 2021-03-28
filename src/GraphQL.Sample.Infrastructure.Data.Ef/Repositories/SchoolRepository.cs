using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Repositories
{
    public class SchoolRepository : BaseRepository<School>, ISchoolRepository
    {
        public SchoolRepository(IDbContextFactory<SchoolDbContext> dbContextFactory) : base(dbContextFactory)
        {

        }
    }
}
