using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppAPI
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private ILogger _logger;
        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var header = Request.Headers["Authorization"];
            return Ok($"Authorization: {header}");
        }

        [Route("redirect")]
        public IActionResult Redirect()
        {
            var redirectUrl = "http://localhost:5001/api/test";
            _logger.LogInformation($"Redirecting to: {redirectUrl}"); 
            return TemporaryRedirect(redirectUrl);
        }

        public IActionResult TemporaryRedirect(string url)
        {
            return new TemporaryRedirectResult(url, null);
        }
    }
}
