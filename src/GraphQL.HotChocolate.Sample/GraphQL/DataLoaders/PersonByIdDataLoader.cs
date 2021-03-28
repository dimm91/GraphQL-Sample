using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Persons;
using GreenDonut;
using HotChocolate.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.DataLoaders
{
    public class PersonByIdDataLoader : BatchDataLoader<int, Person>
    {
        private readonly IPersonService _personService;
        public PersonByIdDataLoader(IPersonService personService, IBatchScheduler batchScheduler) : base(batchScheduler)
        {
            _personService = personService;
        }

        protected override async Task<IReadOnlyDictionary<int, Person>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var persons = await _personService.GetPersons(keys);
            return persons.ToDictionary(p => p.PersonId, p => p);
        }
    }
}
