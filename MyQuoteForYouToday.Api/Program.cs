using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyQuoteForYouToday.Business.Services;
using MyQuoteForYouToday.Business.Services.Interfaces;
using MyQuoteForYouToday.Data.Context;
using MyQuoteForYouToday.Data.Context.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var databaseServerName = builder.Configuration.GetValue<string?>("Parameter:DatabaseServerName");
var databaseName = builder.Configuration.GetValue<string?>("Parameter:DatabaseName");

if (string.IsNullOrEmpty(databaseServerName) || string.IsNullOrEmpty(databaseName))
{
    Console.WriteLine("Database Server Name or Database Name is not set");
    throw new Exception("Database Server Name or Database Name is not set");
}

builder.AddNpgsqlDbContext<MyQuoteForYouTodayContext>(databaseName);
builder.Services.AddScoped<IMyQuoteForYouTodayContext>(sp =>
    sp.GetRequiredService<MyQuoteForYouTodayContext>());
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();