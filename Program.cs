using demo.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ApplicationDbContext>(x => x.UseSqlServer("Data Source=legion-5-pro;Initial Catalog=demo;Integrated Security=True;Pooling=False"));


builder.Services.AddInMemorySubscriptions();

builder.Services.AddScoped<Resolver>();
builder.Services.AddGraphQLServer()
    .AddQueryType<QueryType>()
    .AddMutationType<MutationType>()
    .AddSubscriptionType<Subscription>();

builder.Services.AddInMemorySubscriptions();

var app = builder.Build();

app.UseRouting();

app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
}
);

app.Run();
