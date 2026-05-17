using Aspire.Hosting;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var database = builder
    .AddPostgres("myquote-db-server")
    .AddDatabase("MyQuoteForYouTodayDb");

builder.AddProject<MyQuoteForYouToday_Api>("Api")
    .WithReference(database)
    .WaitFor(database);

builder.Build().Run();
