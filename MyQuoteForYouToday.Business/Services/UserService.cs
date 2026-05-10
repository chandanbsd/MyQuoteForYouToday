using MyQuoteForYouToday.Business.Services.Interfaces;
using MyQuoteForYouToday.Contract;
using MyQuoteForYouToday.Data.Context.Interfaces;
using MyQuoteForYouToday.Data.Entities;

namespace MyQuoteForYouToday.Business.Services;

/// <summary>
/// The user service.
/// </summary>
public class UserService(
    IMyQuoteForYouTodayContext dbContext) : IUserService
{
    /// <inheritdoc cref="IUserService.GetUser"/>
    public async Task<User?> GetUser(string userName)
    {
        return await dbContext.GetUser(userName);
    }

    /// <summary>
    /// Creates the user.
    /// </summary>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
    /// <param name="userName">The user name.</param>
    /// <returns>The user.</returns>
    public async Task<UserDto?> CreateUser(string firstName, string lastName, string userName)
    {
        var user = User.Create(firstName, lastName, userName, -1);
        await dbContext.AddEntity(user, true);

        return new UserDto(
            user.FirstName,
            user.LastName,
            user.UserName);
    }
}
