using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var databaseServerName = builder.Configuration["Parameters:DatabaseServerName"];
var databaseName = builder.Configuration["Parameters:DatabaseName"];

if (string.IsNullOrWhiteSpace(databaseServerName) || string.IsNullOrWhiteSpace(databaseName))
{
    throw new InvalidOperationException("Please provide Parameters:DatabaseServerName and Parameters:DatabaseName.");
}

var database = builder
    .AddPostgres(databaseServerName)
    .AddDatabase(databaseName);

var migrations = builder.AddProject<MyQuoteForYouToday_MigrationService>("migrations")
    .WithReference(database)
    .WaitFor(database);

builder.AddProject<MyQuoteForYouToday_Api>("Api")
    .WithReference(database)
    .WaitFor(database)
    .WaitFor(migrations);

builder.Build().Run();
