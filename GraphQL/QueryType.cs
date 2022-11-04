namespace demo.GraphQL
{
    public class QueryType
    {
        private readonly Resolver _resolver;
        public QueryType(Resolver resolver)
        {
            _resolver = resolver;
        }

        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            IEnumerable<Users> users = await _resolver.getUsers();
            return users;
        }
    }
}
