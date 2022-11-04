using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace demo.GraphQL
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public ValueTask<ISourceStream<Users>> userUpdated(Users updated_users, [Service] ITopicEventReceiver topicEventReceiver)
        {
            string updated_user = $"{updated_users.Id}_{nameof(Subscription.userUpdated)}";

            return topicEventReceiver.SubscribeAsync<string, Users>(updated_user);
        }
    }
}
