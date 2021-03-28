using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Repositories
{
    public class CourseStudentsRepository : BaseRepository<CourseStudent>, ICourseStudentsRepository
    {
        public CourseStudentsRepository(IDbContextFactory<SchoolDbContext> dbContextFactory) : base(dbContextFactory)
        {

        }
    }
}
