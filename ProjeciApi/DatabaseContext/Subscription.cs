using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using ProjeciApi.Models;

namespace ProjeciApi.DatabaseContext
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Company>> OnCompanyCreate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Company>("CompanyCreated", cancellationToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Personel>> OnEmployeeGet([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Personel>("ReturnedEmployee", cancellationToken);
        }
    }
}
