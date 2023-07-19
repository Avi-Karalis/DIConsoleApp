using DIConsoleApp.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIConsoleApp.Implementations {
    public class BarService : IBarService {
        private readonly IFooService _fooService;
        private readonly IConfiguration _config;
        public BarService(IFooService fooService, IConfiguration config) =>(_fooService, _config) = (fooService, config);
        
        public void DoSomeWork() {
           for (int i = 0; i < _config.GetValue<int>("LoopTimes"); i++) {
                _fooService.DoTheThing(i);
            }
        }
    }
}
