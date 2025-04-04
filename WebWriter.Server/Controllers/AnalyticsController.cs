using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebWriter.Server.Services;

namespace WebWriter.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly ILogger<AnalyticsController> _logger;

        private readonly Analytics _analytics;

        public AnalyticsController(Analytics analytics, ILogger<AnalyticsController> logger)
        {
            _analytics = analytics;
            _logger = logger;

        }

        [HttpGet("getConsistencyAnalytics")]
        public async Task<IActionResult> GetConsistencyAnalytics([FromQuery] string fictionUrl)
        {
            if (string.IsNullOrEmpty(fictionUrl))
            {
                return BadRequest(new { error = "Missing or invalid query parameter: fictionUrl" });
            }

            try
            {
                var result = await _analytics.GetConsistencyAnalytics(fictionUrl);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("getFiction")]
        public async Task<IActionResult> GetFiction([FromQuery] string fictionUrl)
        {
            if (string.IsNullOrEmpty(fictionUrl))
            {
                return BadRequest(new { error = "Missing or invalid query parameter: fictionUrl" });
            }

            try
            {
                var result = await _analytics.GetFictionObj(fictionUrl);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        
    }
}
