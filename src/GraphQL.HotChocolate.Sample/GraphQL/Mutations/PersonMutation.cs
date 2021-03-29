using GraphQL.HotChocolate.Sample.GraphQL.Subscriptions;
using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Service.Services.Persons;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.HotChocolate.Sample.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class PersonMutation
    {
        public record AddPersonInput(string Name, string Lastname, string Email, PersonType PersonType);
        public record SimulateAddPersonInput(string Name, string Lastname, string Email, PersonType PersonType);
        public async Task<Person> AddPersonAsync(
         [GraphQLNonNullType] AddPersonInput input,
         [Service] IPersonService personService)
        {
            var person = await personService.GetPersonByEmail(input.Email);
            if (person != null)
            {
                throw new Exception("A person already exist with the email");
            }

            return await personService.InsertPerson(input.Name, input.Lastname, input.Email, input.PersonType);
        }

        /// <summary>
        /// FYI. A Mutation should always return a value, otherwise this will not me mapped in the list of mutations.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="eventSender"></param>
        /// <returns></returns>
        public async Task<Person> AddPersonSendMessageToTopicAsync(
            [GraphQLNonNullType] SimulateAddPersonInput input,
            [Service] ITopicEventSender eventSender)
        {
            await eventSender.SendAsync(nameof(SampleSubscription.OnPersonCreatedSubscriptionAsync), input);
            return new Person(input.Name, input.Lastname, input.Email, input.PersonType);
        }
    }
}
