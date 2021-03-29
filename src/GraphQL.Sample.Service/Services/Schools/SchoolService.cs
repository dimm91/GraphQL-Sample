using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.Schools
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        public async Task<IEnumerable<School>> GetSchools()
        {
            return await _schoolRepository.GetListAsync(_ => true);
        }

        public async Task<School> InsertSchool(string name, string countryCode, string address)
        {
            var school = new School(name, countryCode, address);
            await _schoolRepository.CreateAsync(school);
            return school;
        }
    }
}
