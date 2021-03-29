using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.Schools
{
    public interface ISchoolService
    {
        Task<IEnumerable<School>> GetSchools();
        Task<School> InsertSchool(string name, string countryCode, string address);
        Task<School> GetSchoolById(int schoolId);
    }
}
