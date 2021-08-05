using WeatherApp;
using System;
using Xunit;

namespace WeatherApp.Tests
{
    public class BreakApplicationServiceTests
    {
        [Fact]
        public void ShouldBreakApplicationOnCallingBreak()
        {
            var service = new BreakApplicationService();
            
            service.BreakMyApplication();
            
            Assert.True(service.IsApplicationBroken, "Application should be broken");
        }
    }
}
