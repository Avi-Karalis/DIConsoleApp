using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

// use DI && SeriLog, use appsettings.json!!!

namespace DiConsoleApp;
internal partial class Program {
    private static void Main(string[] args) {
        var builder = new ConfigurationBuilder();
        BuildConfig(builder);

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Build()) 
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        Log.Logger.Information("Application Starting");

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => {
                services.AddTransient<IGreetingService,GreetingService>();
            })
            .UseSerilog()
            .Build();

        var svc = ActivatorUtilities.CreateInstance<GreetingService>(host.Services);

        svc.Run();
    }

    // configure the logger. and pass the refernece of the configbuilder
    private static void BuildConfig(IConfigurationBuilder configBuilder) {
        //search your current directory for JSON. It's mandatory, and you must reload it anytime it is changed
        configBuilder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            //if there is a developmentjson use is otherwise use the one you have.
            .AddJsonFile($"appsetings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
            .AddEnvironmentVariables();
    }
}