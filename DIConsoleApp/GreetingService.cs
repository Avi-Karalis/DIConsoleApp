using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

// use DI && SeriLog, use appsettings.json!!!

namespace DiConsoleApp;
internal partial class Program {
    public class GreetingService : IGreetingService {
        private readonly ILogger<GreetingService> _log;
        private readonly IConfiguration _config;

        public GreetingService(ILogger<GreetingService> log, IConfiguration config) => (_log, _config) = (log, config);

        public void Run() {
            for (int i = 0; i < _config.GetValue<int>("LoopTimes"); i++) {
                _log.LogInformation("Run number {runNumber}", i);
            }
        }
    }
}