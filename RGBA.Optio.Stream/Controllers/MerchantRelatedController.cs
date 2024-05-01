using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using RGBA.Optio.Stream.DecerializerCLasses;
using RGBA.Optio.Stream.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        [Route("ValuteCourse")]
        public async Task LoadCurrencies()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://nbg.gov.ge/gw/api/ct/monetarypolicy/currencies/en/json");
                    response.EnsureSuccessStatusCode(); 
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var currenciesResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CurrenciesResponse>>(responseBody);
                     await ITransactionRelatedSer.InsertCurrencies(currenciesResponse);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON deserialization failed: {ex.Message}");
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
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
