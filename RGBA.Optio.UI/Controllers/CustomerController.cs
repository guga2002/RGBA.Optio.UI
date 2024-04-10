using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Localization;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Interfaces.InterfacesForTransaction;
using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICurrencyRelatedService ser;

        [HttpGet]
        [Route("/Currency")]
        public async Task<IActionResult> GetDemo()
        {
            var res = await ser.GetAllAsync(new CurrencyModel() { CurrencyCode = "undefined", NameOfValute = "undefined" });
            return Ok(res);
        }
    }

}
