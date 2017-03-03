using Microsoft.AspNetCore.Mvc;

namespace AppAPI
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var header = Request.Headers["Authorization"];
            return Ok($"Authorization: {header}");
        }

        [Route("redirect")]
        public IActionResult Redirect()
        {
            return TemporaryRedirect("http://localhost:5001/api/test");
        }

        public IActionResult TemporaryRedirect(string url)
        {
            return new TemporaryRedirectResult(url, null);
        }
    }
}
