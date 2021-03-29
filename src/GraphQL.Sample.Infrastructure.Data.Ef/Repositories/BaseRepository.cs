using GraphQL.Sample.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected SchoolDbContext _SchoolDbContext;
        private readonly IDbContextFactory<SchoolDbContext> _contextFactory;

        public BaseRepository(IDbContextFactory<SchoolDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task CreateAsync(T model)
        {
            using (var schoolDbContext = _contextFactory.CreateDbContext())
            {
                await schoolDbContext.Set<T>().AddAsync(model);
                await schoolDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> wherePredicate)
        {
            using var schoolDbContext = _contextFactory.CreateDbContext();
            return await schoolDbContext.Set<T>().Where(wherePredicate).AsQueryable().ToListAsync();
        }

        public Task UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetElementAsync(Expression<Func<T, bool>> predicate)
        {
            using var schoolDbContext = _contextFactory.CreateDbContext();
            return await schoolDbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }
}
