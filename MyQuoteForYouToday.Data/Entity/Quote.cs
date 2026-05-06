using System;

namespace MyQuoteForYouToday.Data.Entities;

/// <summary>
/// The quote entity.
/// </summary>
public class Quote
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
    /// Gets the text.
    /// </summary>
    public string Text { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the author identifier.
    /// </summary>
    public int? AuthorId { get; private set; }
}