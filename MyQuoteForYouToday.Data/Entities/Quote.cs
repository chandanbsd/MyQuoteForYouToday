namespace MyQuoteForYouToday.Data.Entities;

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
    public string Text { get; private set; }
    
    /// <summary>
    /// Gets the author identifier.
    /// </summary>
    public int? AuthorId { get; private set; }
}