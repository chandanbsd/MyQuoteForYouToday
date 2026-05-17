using System;
using System.ComponentModel.DataAnnotations;

namespace MyQuoteForYouToday.Data.Entities;

/// <summary>
/// The quote entity.
/// </summary>
public class Quote : Audit
{
    /// <summary>
    /// Gets the text.
    /// </summary>
    [Required]
    [MaxLength(1000)]
    public string Text { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the author identifier.
    /// </summary>
    public int? AuthorId { get; private set; }
}