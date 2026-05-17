using MyQuoteForYouToday.Data.Constants;
using MyQuoteForYouToday.Data.Context;
using MyQuoteForYouToday.Data.Entities;

namespace MyQuoteForYouToday.MigrationService;

using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

using OpenTelemetry.Trace;

using MyQuoteForYouToday.Data;

/// <summary>
/// The worker.
/// </summary>
/// <param name="serviceProvider">The service provider.</param>
/// <param name="hostApplicationLifetime">The host application lifetime.</param>
public class Worker(
    IServiceProvider serviceProvider,
    IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
{
    /// <summary>
    /// The activity source name.
    /// </summary>
    public const string ActivitySourceName = "Migrations";

    /// <summary>
    /// The activity source.
    /// </summary>
    private static readonly ActivitySource ActivitySource = new (ActivitySourceName);

    /// <summary>
    /// The execute async.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected override async Task ExecuteAsync(
        CancellationToken cancellationToken)
    {
        using var activity = ActivitySource.StartActivity(
            name: "Migrating database",
            ActivityKind.Client);

        try
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<MyQuoteForYouTodayContext>();

            await RunMigrationAsync(dbContext, cancellationToken);
            await SeedDataAsync(dbContext, cancellationToken);
        }
        catch (Exception ex)
        {
            activity?.AddException(ex);
            throw;
        }

        hostApplicationLifetime.StopApplication();
    }

    private static async Task RunMigrationAsync(
        MyQuoteForYouTodayContext dbContext,
        CancellationToken cancellationToken)
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            // Run migration in a transaction to avoid partial migration if it fails.
            await dbContext.Database.MigrateAsync(cancellationToken);
        });
    }

    private static async Task SeedDataAsync(
        MyQuoteForYouTodayContext dbContext,
        CancellationToken cancellationToken)
    {
        User systemUser = User.Create(
            "SYSTEM",
            "SYSTEM",
            "system",
            UserConstant.SystemUserId);

        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            // Seed the database
            await using var transaction = await dbContext.Database
                .BeginTransactionAsync(cancellationToken);

            await dbContext.AddEntity<User>(systemUser, true, cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        });
    }
}