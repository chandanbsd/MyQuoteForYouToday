using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var username = builder.AddParameter("PostgresUser", secret: true);
var password = builder.AddParameter("PostgresPassword", secret: true);

var database = builder
    .AddPostgres("postgres", username, password)
    .AddDatabase("myquotedb");

var migrations = builder.AddProject<MyQuoteForYouToday_MigrationService>("migrations")
    .WithReference(database)
    .WaitFor(database);

builder.AddProject<MyQuoteForYouToday_Api>("api")
    .WithReference(database)
    .WaitFor(database)
    .WaitFor(migrations);

builder.Build().Run();
