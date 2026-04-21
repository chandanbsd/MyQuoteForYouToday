// <copyright file="MyQuoteForTodayContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using MyQuoteForYouToday.Data.Entities;

namespace MyQuoteForYouToday.Data.Context;

/// <summary>
/// The my quote for today context.
/// </summary>
public partial class MyQuoteForYouTodayContext : DbContext
{

    /// <summary>
    /// Initializes a new instance of the <see cref="MyQuoteForYouTodayContext"/> class.
    /// </summary>
    public MyQuoteForYouTodayContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Gets the authors.
    /// </summary>
    public DbSet<Author> Authors { get; private set; }
    
    /// <summary>
    /// Gets the quotes.
    /// </summary>
    public DbSet<Quote> Quotes { get; private set; }
    
    /// <summary>
    /// Gets the users.
    /// </summary>
    public DbSet<User> Users { get; private set; }
}