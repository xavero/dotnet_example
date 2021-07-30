using System;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakController : ControllerBase
    {
        private readonly IBreakApplicationService _breakApplication;

        public BreakController(IBreakApplicationService breakApplication)
        {
            if (breakApplication is null)
            {
                throw new ArgumentNullException(nameof(breakApplication));
            }

            _breakApplication = breakApplication;
        }

        [HttpGet, Route("")]
        public void Get()
        {
            _breakApplication.BreakMyApplication();
        }
    }
}
