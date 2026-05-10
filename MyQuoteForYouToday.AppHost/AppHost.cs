using System;
using Aspire.Hosting;
using Microsoft.Extensions.Configuration;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

string? databaseServerName = null,
    databaseName = null,
    databaseUserName = null;

try
{
    databaseServerName = builder.Configuration.GetValue<string>("DatabaseServer:ServerName");
    databaseName = builder.Configuration.GetValue<string>("DatabaseServer:DatabaseName");
    databaseUserName = builder.Configuration.GetValue<string>("DatabaseServer:UserName");

    if (string.IsNullOrEmpty(databaseServerName)
        || string.IsNullOrEmpty(databaseName)
        || string.IsNullOrEmpty(databaseUserName))
    {
        Console.WriteLine("Required configuration values are not set");
        return;
    }

    var databaseServer = builder.AddPostgres(
        name: databaseServerName);
    var database = databaseServer.AddDatabase(
        name: databaseName);

    var api = builder
        .AddProject<MyQuoteForYouToday_Api>("Api")
        .WithReference(database);

    builder.Build().Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}
