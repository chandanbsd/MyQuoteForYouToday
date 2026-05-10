using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Logging;
using MyQuoteForYouToday.Data.Context.Interfaces;
using MyQuoteForYouToday.Data.Entity;
using MyQuoteForYouToday.Data.Entity.Interface;

namespace MyQuoteForYouToday.Data.Context;

/// <summary>
/// My quote for you today context.
/// </summary>
public partial class MyQuoteForYouTodayContext
{
    /// <inheritdoc cref="IMyQuoteForYouTodayContext.AddEntity{T}(T)"/>
    public Task AddEntity<T>(T entity)
        where T : class
        => AddEntity(entity, saveChanges: true);

    /// <inheritdoc cref="IMyQuoteForYouTodayContext.AddEntity{T}(T)"/>
    public async Task AddEntity<T>(T entity, bool saveChanges)
        where T : class
    {
        Set<T>().Add(entity);
        if (saveChanges)
        {
            await SaveChangesAsync();
        }
    }

    /// <inheritdoc cref="IMyQuoteForYouTodayContext.GetEntity{T}(Guid)"/>
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
