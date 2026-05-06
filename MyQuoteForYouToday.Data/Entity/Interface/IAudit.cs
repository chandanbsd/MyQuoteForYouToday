namespace MyQuoteForYouToday.Data.Entity.Interface;

/// <summary>
/// The base entity.
/// </summary>
public interface IAudit
{
    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets the Guid.
    /// </summary>
    public Guid Guid { get; }

    /// <summary>
    /// Gets the created on.
    /// </summary>
    public DateTime CreatedOn { get; }

    /// <summary>
    /// Gets the updated on.
    /// </summary>
    public DateTime? UpdatedOn { get; }

    /// <summary>
    /// Gets the created by identifier.
    /// </summary>
    public int CreatedById { get; }

    /// <summary>
    /// Gets the updated by identifier.
    /// </summary>
    public int? UpdatedById { get; }
}
