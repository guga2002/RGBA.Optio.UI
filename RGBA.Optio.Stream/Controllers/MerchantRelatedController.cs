using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RGBA.Optio.Stream.Interfaces;

namespace RGBA.Optio.Stream.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantRelatedController : ControllerBase
    {
        private readonly IMerchantRelatedSer _merchantRelatedService;
        public MerchantRelatedController(IMerchantRelatedSer _merchantRelatedService)
        {
            this._merchantRelatedService = _merchantRelatedService;
        }
        [HttpGet]
        public async Task<IActionResult> FillDataToLocation()
        {
            await _merchantRelatedService.FillDataToLocation();
            return Ok();
        }
    }
}
