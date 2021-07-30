using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace WeatherApp
{
    public class ApplicationSlowedMiddleware : IMiddleware
    {
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        private readonly IOptions<SimulationConfig> _config;
        private readonly Random _random;

        public ApplicationSlowedMiddleware(IOptions<SimulationConfig> config)
        {
            this._config = config ?? throw new ArgumentNullException(nameof(config));
            _random = new Random();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (_config.Value.Slow)
            {
                await semaphoreSlim.WaitAsync();

                try
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(_random.Next(50, 1500)));
                }
                finally
                {
                    semaphoreSlim.Release();
                }
            }

            await next(context);
        }
    }
}
