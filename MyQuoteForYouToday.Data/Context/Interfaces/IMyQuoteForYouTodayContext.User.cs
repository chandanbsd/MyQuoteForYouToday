namespace MyQuoteForYouToday.Data.Context.Interfaces;

/// <summary>
/// The user context.
/// </summary>
public partial interface IMyQuoteForYouTodayContext
{
    /// <summary>
    /// Gets the user.
    /// </summary>
    /// <param name="userName">The account identifier.</param>
    /// <returns>The user.</returns>
    Task<User?> GetUser(string userName);
}