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
        private readonly ITransactionRelatedSer ITransactionRelatedSer;
        public MerchantRelatedController(IMerchantRelatedSer _merchantRelatedService, ITransactionRelatedSer ITransactionRelatedSer)
        {
            this._merchantRelatedService = _merchantRelatedService;
            this.ITransactionRelatedSer = ITransactionRelatedSer;
        }

        [HttpGet]
        [Route("Location")]
        public async Task<IActionResult> FillDataToLocation()
        {
            await _merchantRelatedService.FillDataToLocation();
            return Ok();
        }

        [HttpGet]
        [Route("Merchant")]
        public async Task<IActionResult> FillDataMerchant()
        {
            await _merchantRelatedService.FillDataMerchant();
            return Ok();
        }
        [HttpPost]
        [Route("AssignLocationToMerchant")]
        public async Task<IActionResult> FillDataLocationToMerchant(int countNumber)
        {
            await _merchantRelatedService.FillDataLocationToMerchant(countNumber);
            return Ok();
        }

        [HttpGet]
        [Route("Channel")]
        public async Task<IActionResult> fillChannel()
        {
            await ITransactionRelatedSer.fillChannel();
            return Ok();
        }
        [HttpGet]
        [Route("TypeOfTransaction")]
        public async Task<IActionResult> FillTypeOfTransaction()
        {
            await ITransactionRelatedSer.FillTypeOfTransaction();
            return Ok();
        }


    }
}
