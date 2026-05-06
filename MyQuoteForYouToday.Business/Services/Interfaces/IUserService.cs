using MyQuoteForYouToday.Data.Entities;

namespace MyQuoteForYouToday.Business.Services.Interfaces;

/// <summary>
/// The user service interface.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Creates the user.
    /// </summary>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
    /// <param name="userName">The user name.</param>
    /// <returns>An empty task.</returns>
    Task CreateUser(
        string firstName,
        string lastName,
        string userName);

    /// <summary>
    /// Gets the user.
    /// </summary>
    /// <param name="userName">The username.</param>
    /// <returns>The user.</returns>
    Task<User?> GetUser(string userName);
}
