using Microsoft.Extensions.Configuration;

internal static class ProgramHelpers {

    // configure the logger. and pass the refernece of the configbuilder
    internal static void BuildConfig(IConfigurationBuilder configBuilder) {
        //search your current directory for JSON. It's mandatory, and you must reload it anytime it is changed
        configBuilder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            //if there is a developmentjson use is otherwise use the one you have.
            .AddJsonFile($"appsetings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
            .AddEnvironmentVariables();
    }
}