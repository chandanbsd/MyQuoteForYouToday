using System;
using System.ComponentModel.DataAnnotations;
using MyQuoteForYouToday.Data.Entity.Interface;

namespace MyQuoteForYouToday.Data.Entities;

/// <summary>
/// The base entity.
/// </summary>
public class Audit : IAudit
{
    /// <summary>
    /// Gets the identifier.
    /// </summary>
    [Required]
    public int Id { get; private set; }

    /// <summary>
    /// Gets the Guid.
    /// </summary>
    [Required]
    public Guid Guid { get; private set; }

    /// <summary>
    /// Gets the created on.
    /// </summary>
    [Required]
    public DateTime CreatedOn { get; private set; }

    /// <summary>
    /// Gets the updated on.
    /// </summary>
    public DateTime? UpdatedOn { get; private set; }

    /// <summary>
    /// Gets the created by identifier.
    /// </summary>
    [Required]
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
