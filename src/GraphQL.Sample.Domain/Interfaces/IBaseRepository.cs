using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task CreateAsync(T model);
        Task UpdateAsync(T model);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> wherePredicate);
    }
}
