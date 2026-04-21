using System;

namespace MyQuoteForYouToday.Data.Entities;

/// <summary>
/// The base entity.
/// </summary>
public class Audit
{
    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the Guid.
    /// </summary>
    public Guid Guid { get; private set; }

    /// <summary>
    /// Gets the created on.
    /// </summary>
    public DateTime CreatedOn { get; private set; }

    /// <summary>
    /// Gets the updated on.
    /// </summary>
    public DateTime? UpdatedOn { get; private set; }

    /// <summary>
    /// Gets the created by identifier.
    /// </summary>
    public int CreatedById { get; private set; }

    /// <summary>
    /// Gets the updated by identifier.
    /// </summary>
    public int? UpdatedById { get; private set; }

    /// <summary>
    /// Creates the base entity.
    /// </summary>
    /// <param name="createdById">The created by identifier.</param>
    public void AuditCreate(int createdById)
    {
        CreatedOn = DateTime.UtcNow;
        CreatedById = createdById;
        Guid = Guid.NewGuid();
    }

    /// <summary>
    /// Creates the base entity.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    public void AuditUpdate(int userId)
    {
        UpdatedOn = DateTime.UtcNow;
        UpdatedById = userId;
    }
}