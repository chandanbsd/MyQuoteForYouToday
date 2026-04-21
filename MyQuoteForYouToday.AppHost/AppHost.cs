#pragma warning disable SA1200
using Microsoft.Extensions.Configuration;
#pragma warning restore SA1200

var builder = DistributedApplication.CreateBuilder(args);

string? databaseServerName = null,
    databaseName = null,
    databaseUserName = null;

try
{
    databaseServerName = builder.Configuration.GetValue<string>("ServerName");
    databaseName = builder.Configuration.GetValue<string>("DatabaseName");
    databaseUserName = builder.Configuration.GetValue<string>("UserName");

    if (string.IsNullOrEmpty(databaseServerName)
        || string.IsNullOrEmpty(databaseName)
        || string.IsNullOrEmpty(databaseUserName))
    {
        Console.WriteLine("Required configuration values are not set");
        return;
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

var database = builder.AddPostgres(
    name: databaseServerName);

builder.Build().Run();
