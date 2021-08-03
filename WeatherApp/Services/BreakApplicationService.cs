using System;
using System.Threading;

namespace WeatherApp
{
    public class BreakApplicationService : IBreakApplicationService
    {
        private int _isBroken = 0;

        public bool IsApplicationBroken => _isBroken > 0;

        public void BreakMyApplication()
        {
            // Interlocked.Increment(ref _isBroken);
        }
    }
}
