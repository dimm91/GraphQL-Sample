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
        //public BaseRepository(SchoolDbContext schoolDbContext = null)
        //{
        //    _SchoolDbContext = schoolDbContext;
        //}
        private readonly IDbContextFactory<SchoolDbContext> _contextFactory;
        
        public BaseRepository(IDbContextFactory<SchoolDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public Task<int> CreateAsync(T model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> wherePredicate)
        {
            using (var schoolDbContext = _contextFactory.CreateDbContext())
            {
                return await schoolDbContext.Set<T>().Where(wherePredicate).AsQueryable().ToListAsync();
            }
            //return default;
            //return await _SchoolDbContext.Set<T>().Where(wherePredicate).AsQueryable().ToListAsync();
        }

        public Task UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }
    }
}
