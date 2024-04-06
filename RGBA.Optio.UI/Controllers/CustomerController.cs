using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RGBA.Optio.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetDemo()
        {
            await Task.Delay(200);
            return Ok("...");
        }
    }

}
