using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RGBA.Optio.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetDemo()
        {
            return Ok("Hello Word");
        }
    }
}
