using MyQuoteForYouToday.Data.Entity.Interface;

namespace MyQuoteForYouToday.Data.Context.Interfaces;

/// <summary>
/// My quote for today context interface.
/// </summary>
public partial interface IMyQuoteForYouTodayContext
{
    /// <inheritdoc cref="MyQuoteForYouTodayContext.AddEntity{T}(T)"/>
    Task AddEntity<T>(T entity)
        where T : class;

    /// <summary>
    /// Gets the entity.
    /// </summary>
    /// <typeparam name="T">Any type that conforms to the entity (class that represents a database table in efcore).</typeparam>
    /// <param name="id">The unique identifier.</param>
    /// <returns>The entity or null if not found.</returns>
    Task<T?> GetEntity<T>(Guid id)
        where T : class, IAudit;

    /// <summary>
    /// Adds an entity to it's dbset.
    /// </summary>
    /// <typeparam name="T">Any type that conforms to the entity (class that represents a database table in efcore).</typeparam>
    /// <param name="entity">The entity.</param>
    /// <param name="saveChanges">A value indicating whether to save changes.</param>
    /// <returns>An empty task.</returns>
    Task AddEntity<T>(T entity, bool saveChanges)
        where T : class;
}
