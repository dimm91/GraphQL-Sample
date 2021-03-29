using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.Persons
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetPersons(IEnumerable<int> personIds);
        Task<IEnumerable<Person>> GetPersonsBytype(PersonType personType);
        Task<Person> GetPersonById(int personId, PersonType personType);
        Task<Person> GetPersonByEmail(string email);
        Task<Person> InsertPerson(string name, string lastname, string email, PersonType PersonType);
    }
}
