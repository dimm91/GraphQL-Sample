﻿using GraphQL.Sample.Domain.Interfaces;
using GraphQL.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Sample.Service.Services.Persons
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<IEnumerable<Person>> GetPersons(IEnumerable<int> personIds)
        {
            return await _personRepository.GetListAsync(x => personIds.Any(p => p == x.PersonId));
        }

        public async Task<IEnumerable<Person>> GetPersonsBytype(PersonType personType)
        {
            return await _personRepository.GetListAsync(x => x.PersonType == personType);
        }
    }
}
