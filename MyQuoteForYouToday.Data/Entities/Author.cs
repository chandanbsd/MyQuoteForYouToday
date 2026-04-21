namespace MyQuoteForYouToday.Data.Entities;

/// <summary>
/// Represents an author of a quote.
/// </summary>
public class Author
{
    /// <summary>
    /// Gets the text.
    /// </summary>
    public string Text { get; private set; }

    /// <summary>
    /// Gets the author identifier.
    /// </summary>
    public int? AuthorId { get; private set; }

    /// <summary>
    /// Gets the author.
    /// </summary>
    public Author Author { get; private set; }
}