using Microsoft.Extensions.Logging;
using MyQuoteForYouToday.Data.Context.Interfaces;

namespace MyQuoteForYouToday.Data.Context;

/// <summary>
/// The my quote for today context.
/// </summary>
/// <param name="logger">The logger.</param>
public partial class MyQuoteForYouTodayContext(
    ILogger<MyQuoteForYouTodayContext> logger) : DbContext, IMyQuoteForYouTodayContext
{
    /// <summary>
    /// Gets the authors.
    /// </summary>
    public DbSet<Author> Authors { get; private set; }

    /// <summary>
    /// Gets the quotes.
    /// </summary>
    public DbSet<Quote> Quotes { get; private set; }

    /// <summary>
    /// Gets the users.
    /// </summary>
    public DbSet<User> Users { get; private set; }

    /// <summary>
    /// The on configuration method.
    /// </summary>
    /// <param name="optionsBuilder">The options builder.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    /// <summary>
    /// The on model creating method.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
