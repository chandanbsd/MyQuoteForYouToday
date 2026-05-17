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

builder.AddNpgsqlDbContext<MyQuoteForYouTodayContext>("MyQuoteForYouTodayDb");
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