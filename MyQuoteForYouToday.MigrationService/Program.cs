using MyQuoteForYouToday.Data.Context;
using MyQuoteForYouToday.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddNpgsqlDbContext<MyQuoteForYouTodayContext>("myquotedb");

var host = builder.Build();
host.Run();
