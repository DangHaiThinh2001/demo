using HotChocolate.Subscriptions;

namespace demo.GraphQL
{
    public class MutationType
    {
        private readonly Resolver _resolver;
        public MutationType(Resolver resolver) { _resolver = resolver; }

        public async Task<Users> createUsersAsync(string name)
        {
            Users users = new Users()
            {
                Id = Guid.NewGuid(),
                Name = name
            };
            users = await _resolver.create(users);
            return users;
        }

        public async Task<Users> updateUsersAsync(Users updated_users, [Service] ITopicEventSender topicEventSender)
        {
            Users users = await _resolver.getUserById(updated_users.Id);

            if(users == null)
            {
                throw new Exception($"Cannot find this user by id {updated_users.Id}");
            }
            else
            {
                users.Name = updated_users.Name;
                users = await _resolver.update(users);
                string update_string = $"{updated_users.Id}_{nameof(Subscription.userUpdated)}";
                topicEventSender.SendAsync(update_string, users);
                return users;
            }
        }

        public async Task<string> deleteUsersAsync(Guid id)
        {
            await _resolver.delete(id);
            return "Delete success!";
        }
    }
}
