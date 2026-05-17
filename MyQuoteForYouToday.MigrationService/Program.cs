using MyQuoteForYouToday.Data.Context;
using MyQuoteForYouToday.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();
var databaseName = builder.Configuration.GetValue<string?>("Parameter:DatabaseName");

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddNpgsqlDbContext<MyQuoteForYouTodayContext>("sqldata");
var host = builder.Build();
host.Run();