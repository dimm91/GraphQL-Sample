using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.Schools
{
    public interface ISchoolService
    {
        //IEnumerable<User> GetUsers();
        Task<IEnumerable<School>> GetSchools();
        //void InsertUser(User user);
        //void UpdateUser(User user);
        //void DeleteUser(long id);
    }
}
