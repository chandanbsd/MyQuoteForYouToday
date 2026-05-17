using System.ComponentModel.DataAnnotations;

namespace MyQuoteForYouToday.Data.Entities;

/// <summary>
/// The user entity.
/// </summary>
public class Author : Audit
{
    /// <summary>
    /// Gets the user's first name.
    /// </summary>
    [Required]
    public string FirstName { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the user's last name.
    /// </summary>
    [Required]
    public string LastName { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the username.
    /// </summary>
    [Required]
    public string UserName { get; private set; } = string.Empty;

    /// <summary>
    /// Creates the user.
    /// </summary>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
    /// <param name="userName">The user name.</param>
    /// <param name="userId">The user identifier.</param>
    /// <returns>The user.</returns>
    public static Author Create(
        string firstName,
        string lastName,
        string userName,
        int userId)
    {
        var user = new Author()
        {
            FirstName = firstName,
            LastName = lastName,
            UserName = userName,
        };

        user.AuditCreate(userId);
        return user;
    }

    /// <summary>
    /// Updates the user.
    /// </summary>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
    /// <param name="userName">The user name.</param>
    public void Update(
        string firstName,
        string lastName,
        string userName)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        AuditUpdate(Id);
    }
}