using DIConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIConsoleApp.Implementations {
    public class BarService : IBarService {
        private readonly IFooService _fooService;

        public BarService(IFooService fooService) =>_fooService = fooService;
        
        public void DoSomeWork() {
           for (int i = 0; i < 10; i++) {
                _fooService.DoTheThing(i);
            }
        }
    }
}
