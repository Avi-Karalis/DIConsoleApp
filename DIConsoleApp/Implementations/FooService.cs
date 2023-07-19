using DIConsoleApp.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIConsoleApp.Implementations {
    public class FooService : IFooService {
        private readonly ILogger<FooService> _logger;
        private readonly IConfiguration _config;
        public FooService(ILogger<FooService> logger, IConfiguration config) => (_logger, _config) = (logger, config);
        public void DoTheThing(int num) {
            _logger.LogInformation($"Doing the thing {num}");
        }
    }
}
