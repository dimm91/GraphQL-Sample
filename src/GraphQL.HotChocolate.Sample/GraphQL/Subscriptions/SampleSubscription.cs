using HotChocolate;
using HotChocolate.Types;
using System;
using System.Threading;
using System.Threading.Tasks;
using static GraphQL.HotChocolate.Sample.GraphQL.Mutations.PersonMutation;

namespace GraphQL.HotChocolate.Sample.GraphQL.Subscriptions
{
    [ExtendObjectType("Subscription")]
    public class SampleSubscription
    {
        [Subscribe]
        [Topic]// The name is where the 'eventSender' will send the message. If is not specified then it will match it to the name of the method
        public async Task<string> OnPersonCreatedSubscriptionAsync(
            [EventMessage] SimulateAddPersonInput message,
            CancellationToken cancellationToken)
        {
            return $"Message Recived at: {DateTime.UtcNow} - Content: {message}";
        }
    }
}
