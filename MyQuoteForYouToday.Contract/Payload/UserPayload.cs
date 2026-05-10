namespace MyQuoteForYouToday.Contract;

/// <summary>
/// The user data transfer object.
/// </summary>
/// <param name="FirstName">The first name.</param>
/// <param name="LastName">The last name.</param>
/// <param name="UserName">The user name.</param>
public record UserPayload(
    string FirstName,
    string LastName,
    string UserName
);
