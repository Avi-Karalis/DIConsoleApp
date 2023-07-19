using DIConsoleApp.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIConsoleApp.Implementations {
    public class FooService : IFooService {
        private readonly ILogger<FooService> _logger;
        public FooService(ILogger<FooService> logger) => _logger = logger;
        public void DoTheThing(int num) {
            _logger.LogInformation($"Doing the thing {num}");
        }
    }
}
