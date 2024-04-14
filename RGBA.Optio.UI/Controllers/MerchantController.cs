
using Microsoft.AspNetCore.Mvc;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantRelatedService ser;
        private readonly ILogger<MerchantController> log;
        public MerchantController(IMerchantRelatedService se, ILogger<MerchantController> log)
        {
            this.ser = se;
            this.log = log;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await ser.GetAllAsync(new MerchantModel());
                    if (!res.Any())
                    {
                        return NotFound();
                    }
                    return Ok(res);
                }
                return BadRequest();
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AllActive()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await ser.GetAllActiveAsync(new MerchantModel());
                    if (!res.Any())
                    {
                        return NotFound();
                    }
                    return Ok(res);
                }
                return BadRequest();
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await ser.GetByIdAsync(id, new MerchantModel());
                    if (res is not null)
                    {
                        return NotFound();
                    }
                    return Ok(res);
                }
                return BadRequest(id);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] MerchantModel value)
        {
            try
            {
                if(ModelState.IsValid&&value is not null)
                {
                  var res= await ser.AddAsync(value);
                   if(res)
                    {
                        return Ok(res);
                    }
                   return StatusCode(405,"SOmethings unusual");
                }
                return BadRequest(value);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
               return BadRequest(exp.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] MerchantModel value)
        {
            try
            {
                if (ModelState.IsValid && value is not null)
                {
                    var res = await ser.UpdateAsync(id,value);
                    if (res)
                    {
                        return Ok(res);
                    }
                    return StatusCode(405, "SOmethings unusual");
                }
                return BadRequest(value);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult>  Delete(Guid id)
        {

            try
            {
                if (ModelState.IsValid )
                {
                    var res = await ser.SoftDeleteAsync(id,new MerchantModel());
                    if (res)
                    {
                        return Ok(res);
                    }
                    return StatusCode(405, "SOmethings unusual");
                }
                return BadRequest(id);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }
        //locationEndpoints
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetLocation()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await ser.GetAllAsync(new locationModel() { LocationName = "Undefined" });
                    if (!res.Any())
                    {
                        return NotFound();
                    }
                    return Ok(res);
                }
                return BadRequest();
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AllActiveLocation()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await ser.GetAllActiveAsync(new locationModel() { LocationName = "Undefined" });
                    if (!res.Any())
                    {
                        return NotFound();
                    }
                    return Ok(res);
                }
                return BadRequest();
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("Location/{id}")]
        public async Task<IActionResult> GetLocation(Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await ser.GetByIdAsync(id, new locationModel() { LocationName = "Undefined" });
                    if (res is not null)
                    {
                        return NotFound();
                    }
                    return Ok(res);
                }
                return BadRequest(id);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("Location")]
        public async Task<IActionResult> Insert([FromBody] locationModel value)
        {
            try
            {
                if (ModelState.IsValid && value is not null)
                {
                    var res = await ser.AddAsync(value);
                    if (res)
                    {
                        return Ok(res);
                    }
                    return StatusCode(405, "Somethings unusual");
                }
                return BadRequest(value);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPut]
        [Route("Location/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] locationModel value)
        {
            try
            {
                if (ModelState.IsValid && value is not null)
                {
                    var res = await ser.UpdateAsync(id, value);
                    if (res)
                    {
                        return Ok(res);
                    }
                    return StatusCode(405, "Somethings unusual");
                }
                return BadRequest(value);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteLocation(Guid id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var res = await ser.SoftDeleteAsync(id, new locationModel() { LocationName = "Undefined" });
                    if (res)
                    {
                        return Ok(res);
                    }
                    return StatusCode(405, "Somethings unusual");
                }
                return BadRequest(id);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }
    }
}
