namespace MyQuoteForYouToday.Data.Context;

using Microsoft.EntityFrameworkCore.Design;

/// <summary>
/// Design-time context factory for Entity Framework tooling.
/// </summary>
public sealed class MyQuoteForYouTodayContextFactory : IDesignTimeDbContextFactory<MyQuoteForYouTodayContext>
{
    /// <inheritdoc />
    public MyQuoteForYouTodayContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyQuoteForYouTodayContext>();

        var connectionString =
            Environment.GetEnvironmentVariable("MYQUOTEFORYOUTODAY_EF_CONNECTION_STRING")
            ?? "Host=localhost;Port=5432;Database=myquoteforyoutoday;Username=postgres;Password=postgres";

        optionsBuilder.UseNpgsql(connectionString);

        return new MyQuoteForYouTodayContext(optionsBuilder.Options);
    }
}
