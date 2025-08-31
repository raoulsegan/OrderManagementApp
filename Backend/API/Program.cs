using API.GraphQL;
using GraphQL.Server.Ui.Voyager;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var AllowSpecificOrigins = "_allowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<OMAContext>(options =>
{
    options.UseInMemoryDatabase("InMemoryDb");
});

//graphql
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering();

var app = builder.Build();

app.UseCors(AllowSpecificOrigins);

app.MapGraphQL();

app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions{ GraphQLEndPoint = "/graphql" });

app.Run();
