using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Logging;
using MyQuoteForYouToday.Data.Entity;
using MyQuoteForYouToday.Data.Entity.Interface;

namespace MyQuoteForYouToday.Data.Context;

/// <summary>
/// The my quote for you today context.
/// </summary>
public partial class MyQuoteForYouTodayContext
{
    /// <summary>
    /// Adds an entity to it's dbset.
    /// </summary>
    /// <typeparam name="T">Any type that conforms to the entity (class that represents a database table in efcore).</typeparam>
    /// <param name="entity">The entity.</param>
    public async void AddEntity<T>(T entity)
        where T : class
    {
        Set<T>().Add(entity);
        await SaveChangesAsync();
    }

    /// <summary>
    /// Gets the entity.
    /// </summary>
    /// <typeparam name="T">Any type that conforms to the entity (class that represents a database table in efcore).</typeparam>
    /// <param name="id">The unique identifier.</param>
    /// <returns>The entity or null if not found.</returns>
    public async Task<T?> GetEntity<T>(Guid id)
        where T : class, IAudit
    {
        try
        {
            return await Set<T>()
                .Where(e => e.Guid == id)
                .FirstOrDefaultAsync();
        }
        catch
        {
            logger.LogError("Could not fetch {entityName} with Guid {entityGuid}", nameof(T), id);
            throw new Exception($"Could not fetch {nameof(T)} with Guid {id}");
        }
    }
}
