using MyQuoteForYouToday.Data.Context.Interfaces;

namespace MyQuoteForYouToday.Data.Context;

using System.Linq;

/// <summary>
/// My quote for today context.
/// </summary>
public partial class MyQuoteForYouTodayContext
{
    /// <inheritdoc cref="IMyQuoteForYouTodayContext.GetUser"/>
    public async Task<User?> GetUser(string userName)
    {
        return await Users
            .Where(u => u.UserName == userName)
            .FirstOrDefaultAsync();
    }
}