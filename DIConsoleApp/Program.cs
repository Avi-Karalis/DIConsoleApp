using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using DIConsoleApp.Implementations;
using DIConsoleApp.Interfaces;

// use DI && SeriLog, use appsettings.json!!!

namespace DiConsoleApp;
internal partial class Program {
    private static void Main(string[] args) {
        var builder = new ConfigurationBuilder();
        ProgramHelpers.BuildConfig(builder);

        var configuration = builder.Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration) 
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        Log.Logger.Information("Application Starting");

        try {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton<IFooService, FooService>()
                .AddSingleton<IBarService, BarService>()
                .BuildServiceProvider();

            serviceProvider.GetService<ILoggerFactory>().AddSerilog();

            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger.LogDebug("Services Created, starting application");

            var bar = serviceProvider.GetService<IBarService>();
            bar.DoSomeWork();

            logger.LogDebug("Job's Done");

        } catch (Exception ex) {
            Log.Fatal(ex, "Oops something crashed");

        } finally {
            Log.CloseAndFlush();

        }
    }
}