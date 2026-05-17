using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var database = builder
    .AddPostgres("postgres")
    .AddDatabase("myquotedb");

var migrations = builder.AddProject<MyQuoteForYouToday_MigrationService>("migrations")
    .WithReference(database)
    .WaitFor(database);

builder.AddProject<MyQuoteForYouToday_Api>("api")
    .WithReference(database)
    .WaitFor(database)
    .WaitFor(migrations);

builder.Build().Run();
