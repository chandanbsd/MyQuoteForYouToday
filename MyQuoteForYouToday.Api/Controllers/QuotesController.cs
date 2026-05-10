// <copyright file="QuotesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MyQuoteForYouToday.Business.Services.Interfaces;
using MyQuoteForYouToday.Contract;

namespace MyQuoteForYouToday.Api.Controllers;

/// <summary>
/// Controller for managing quotes.
/// </summary>
[ApiController]
[Route("[controller]")]
public class QuotesController (IUserService userService) : ControllerBase
{
    /// <summary>
    /// Creates the user.
    /// </summary>
    /// <param name="user">The user payload.</param>
    /// <returns>The user data transfer object.</returns>
    [HttpPost]
    public async Task<UserDto?> CreateUser(UserPayload user)
    {
        return await userService.CreateUser(
            user.FirstName,
            user.LastName,
            user.UserName);
    }
}