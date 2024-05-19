using Microsoft.AspNetCore.Mvc;
using RGBA.Optio.Domain.Interfaces.StatisticInterfaces;
using RGBA.Optio.Domain.Models.RequestModels;

namespace RGBA.Optio.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticTransactionRelatedService transactionrelatedstatistic;

        public StatisticController(IStatisticTransactionRelatedService transactionrelatedstatistic)
        {
                this.transactionrelatedstatistic=transactionrelatedstatistic;
        }

        [HttpPost]
        [Route("MostPopularCategory")]
        public async Task<IActionResult> GetMostPopularCategoryAsync(DateRangeRequestModel date)
        {
            try
            {
               var result = await transactionrelatedstatistic.GetMostPopularCategoryAsync(date.start,date.end);
                if(!result.Any())
                {
                    return NotFound("No data exist on this range");
                }
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("TransactionQuantityWithDate")]
        public async Task<IActionResult> GetTransactionQuantityWithDateAsync([FromBody] DateRangeRequestModel date)
        {
            try
            {
                var result = await transactionrelatedstatistic.GetTransactionQuantityWithDateAsync(date.start, date.end);
                if (!result.Any())
                {
                    return NotFound("No data exist on this range");
                }
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("AllTransactionBetweenDate")]
        public async Task<IActionResult> GetAllTransactionBetweenDate([FromBody]DateRangeRequestModel date)
        {
            try
            {
                var result = await transactionrelatedstatistic.GetAllTransactionBetweenDate(date.start, date.end);
                if (!result.Any())
                {
                    return NotFound("No data exist on this range");
                }
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
