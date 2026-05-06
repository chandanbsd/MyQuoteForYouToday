namespace MyQuoteForYouToday.Data.Context;

using System.Linq;

/// <summary>
/// My quote for today context.
/// </summary>
public partial class MyQuoteForYouTodayContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MyQuoteForYouTodayContext"/> class.
    /// </summary>
    public MyQuoteForYouTodayContext()
    {
    }

    /// <inheritdoc cref="IUserService.GetUser"/>
    public async Task<User?> GetUser(string userName)
    {
        return await Users
            .Where(u => u.UserName == userName)
            .FirstOrDefaultAsync();
    }
}