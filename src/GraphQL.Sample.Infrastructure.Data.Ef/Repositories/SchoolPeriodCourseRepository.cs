using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Repositories
{
    public class SchoolPeriodCourseRepository : BaseRepository<SchoolPeriodCourse>, ISchoolPeriodCourseRepository
    {
        public SchoolPeriodCourseRepository(IDbContextFactory<SchoolDbContext> dbContextFactory) : base(dbContextFactory)
        {

        }
    }
}
