using Microsoft.AspNetCore.Mvc;
using RGBA.Optio.Domain.Custom_Exceptions;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Models;
using System.Numerics;

namespace RGBA.Optio.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyRelatedService ser;
        private readonly ILogger<CurrencyController> Log;
        public CurrencyController(ICurrencyRelatedService se, ILogger<CurrencyController> Log)
        {
            this.ser = se;
            this.Log = Log;
        }

        [HttpPost]
        [Route("currency")]
        public async Task<IActionResult> Add([FromBody]CurrencyModel entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException(entity.CurrencyCode);
                }
                var res = await ser.AddAsync(entity);
                if(res)
                {
                    return Ok(entity);
                }
                return BadRequest("bad request");
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }
        [HttpPost]
        [Route("valute")]
        public async  Task<IActionResult> Add([FromBody]ValuteModel entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException(entity.DateOfValuteCourse.ToShortDateString());
                }
                var res = await ser.AddAsync(entity);
                if (res)
                {
                    return Ok(entity.DateOfValuteCourse.ToShortTimeString());
                }
                return BadRequest("bad request");
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("currency/active")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            try
            {
                var res =await ser.GetAllActiveAsync(new CurrencyModel() { CurrencyCode="Undefined",NameOfValute="Undefined"});
                return Ok(res);
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("Valute/[action]")]
        public async Task<IActionResult> AllActiveValute()
        {
            try
            {
                var res = await ser.GetAllActiveAsync(new ValuteModel() { DateOfValuteCourse=DateTime.Now,ExchangeRate=0,CurrencyID=0});
                return Ok(res);
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("currency")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var res = await ser.GetAllActiveAsync(new CurrencyModel() {CurrencyCode="Undefined",NameOfValute="Undefined"});
                return Ok(res);
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("valute")]
        public async Task<IActionResult> GetAllValuteAsync()
        {
            try
            {
                var res = await ser.GetAllActiveAsync(new ValuteModel() { CurrencyID = 0, ExchangeRate = 0, DateOfValuteCourse = DateTime.Now });
                return Ok(res);
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet()]
        [Route("currency/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromQuery]int id)
        {
            try
            {
                var res = await ser.GetByIdAsync(id, new CurrencyModel() { CurrencyCode = "Undefined",NameOfValute="Undefined"});
                return Ok(res);
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("valute/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromQuery]BigInteger id)
        {
            try
            {
                var res = await ser.GetByIdAsync(id, new ValuteModel() {CurrencyID=0,ExchangeRate=0,DateOfValuteCourse=DateTime.Now});
                return Ok(res);
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete]
        [Route("currency")]
        public async Task<IActionResult> RemoveAsync([FromBody] CurrencyModel entity)
        {
            try
            {
                var res = await ser.RemoveAsync(entity);
                return Ok(res);
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete]
        [Route("valute")]
        public  async Task<IActionResult> RemoveAsync([FromBody] ValuteModel entity)
        {
            try
            {
                var res = await ser.RemoveAsync(entity);
                return Ok(res);
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("currency/{id}/[action]")]
        public async Task<IActionResult> SoftDelete([FromQuery] int id)
        {
            try
            {
                var res = await ser.SoftDeleteAsync(id,new CurrencyModel() { CurrencyCode="undefined",NameOfValute="undefined"});
                return Ok(res);
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("valute/{id}/[action]")]
        public async Task<IActionResult> SoftDelete([FromQuery] BigInteger id)
        {
            try
            {
                var res = await ser.SoftDeleteAsync(id, new ValuteModel() {CurrencyID=0,ExchangeRate=0,DateOfValuteCourse=DateTime.Now});
                return Ok(res);
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }
        [HttpPut]
        [Route("currency/{id}")]
        public async Task<IActionResult> UpdateAsync([FromQuery] int id,[FromBody]CurrencyModel entity)
        {
            try
            {
                var res = await ser.UpdateAsync(id, new CurrencyModel() {CurrencyCode="Undefined",NameOfValute="Undefined" });
                return Ok(res);
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPut]
        [Route("valute/{id}")]
        public async Task<IActionResult> UpdateAsync([FromQuery] BigInteger id,[FromBody]ValuteModel mod)
        {
            try
            {
                var res = await ser.UpdateAsync(id,mod);
                return Ok(res);
            }
            catch (Exception exp)
            {
                Log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }
    }
}
