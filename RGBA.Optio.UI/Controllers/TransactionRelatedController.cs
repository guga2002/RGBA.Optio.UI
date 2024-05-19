using Microsoft.AspNetCore.Mvc;
using RGBA.Optio.Domain.Custom_Exceptions;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionRelatedController : ControllerBase
    {
        private readonly ITransactionRelatedService ser;
        private readonly ILogger<TransactionRelatedController> log;
        public TransactionRelatedController(ITransactionRelatedService se, ILogger<TransactionRelatedController> log)
        {
            this.ser = se;
            this.log = log;

        }
        [HttpPost]
        [Route("chanell")]
        public async Task<IActionResult> AddAsync([FromBody] ChanellModel entity)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    throw new OptioGeneralException(entity.ChannelType);
                    
                }
                var res = await ser.AddAsync(entity);
                if(res !=-1)
                {
                    var link = Url.Link("DefaultApi", new { controller = "TransactionRelated", action = "GetChanellByIdAsync", id = res });
                    return Created(link, res);
                }
                return BadRequest(entity);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("category")]
        public async  Task<IActionResult> AddAsync([FromBody]CategoryModel entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException(entity.TransactionCategory);

                }
                var res = await ser.AddAsync(entity);
                return res == -1 ? Ok(res) : BadRequest(entity.TransactionCategory);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("transactiontype")]
        public async Task<IActionResult> AddAsync([FromBody] TransactionTypeModel entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException(entity.TransactionName);

                }
                var res = await ser.AddAsync(entity);
                return res == -1 ? Ok(res) : BadRequest(entity.TransactionName);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("chanell/active")]
        public async Task<IActionResult> GetAllActivecChanellAsync()
        {
            try
            {
                var res = await ser.GetAllActiveAsync(new ChanellModel() { ChannelType = "Undefined" });
                return Ok(res);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("category/active")]
        public  async Task<IActionResult> GetAllActiveCategorryAsync()
        {
            try
            {
                var res = await ser.GetAllActiveAsync(new CategoryModel() { TransactionCategory = "Undefined", TransactionTypeID = 0 });
                return Ok(res);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("transactiontype/active")]
        public async Task<IActionResult> GetAllActiveTransactionAsync()
        {
            try
            {
                var res = await ser.GetAllActiveAsync(new TransactionTypeModel() {TransactionName="Undefined"});
                return Ok(res);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("Chanell")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var res = await ser.GetAllAsync(new ChanellModel() { ChannelType="Undefined"});
                return Ok(res);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("category")]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            try
            {
                var res = await ser.GetAllAsync(new CategoryModel() { TransactionCategory="undefined",TransactionTypeID=0 });
                return Ok(res);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("transactiontype")]
        public async Task<IActionResult> GetAllTransactionTypeAsync()
        {
            try
            {
                var res = await ser.GetAllAsync(new TransactionTypeModel() { TransactionName="UNDEFINED"});
                return Ok(res);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("chanell/{id:long}")]
        public async  Task<IActionResult> GetChanellByIdAsync([FromRoute]long id)
        {
            try
            {
                var res = await ser.GetByIdAsync(id,new ChanellModel() { ChannelType = "UNDEFINED" });
                return Ok(res);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("category/{id:long}")]
        public async Task<IActionResult> GetcategoryByIdAsync([FromRoute]long id)
        {
            try
            {
                var res = await ser.GetByIdAsync(id, new CategoryModel() { TransactionCategory = "UNDEFINED",TransactionTypeID=0 });
                return Ok(res);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("transactiontype/{id:long}")]
        public async Task<IActionResult> GetTransactionTypeByIdAsync([FromRoute] long id)
        {
            try
            {
                var res = await ser.GetByIdAsync(id, new TransactionTypeModel() { TransactionName = "UNDEFINED" });
                return Ok(res);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete]
        [Route("chanell/{id:long}")]
        public async  Task<IActionResult> RemoveChanellAsync([FromRoute] long id)
        {
            try
            {
                var res = await ser.RemoveAsync(id,new ChanellModel() { ChannelType="undefined"});
                return res == true ? Ok(res) : BadRequest("Data do not exist");
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete]
        [Route("category/{id:long}")]
        public async Task<IActionResult> RemoveCategoryAsync([FromRoute] long id)
        {
            try
            {
                var res = await ser.RemoveAsync(id,new CategoryModel() { TransactionCategory="undefined",TransactionTypeID=34,});
                return res == true ? Ok(res) : BadRequest("Data do not exist");
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete]
        [Route("transactiontype/{id:long}")]
        public async Task<IActionResult> RemoveTransactionTypeAsync([FromRoute] long id)
        {
            try
            {
                var res = await ser.RemoveAsync(id,new TransactionTypeModel() { TransactionName="undefined"});
                if (res)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest("Data do not exist");
                }
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("chanell/{id:long}/softdelete")]
        public async Task<IActionResult> ChanellSoftDeleteAsync([FromRoute] long id)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    throw new OptioGeneralException("shecdoma gvaqvs");
                 }
                var res = await ser.SoftDeleteAsync(id, new ChanellModel() { ChannelType = "UNDEFINED" });
                return res == true ? Ok(res) : BadRequest("No  data exist on this Id");
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("category/{id:long}/softdelete")]
        public async Task<IActionResult> CategorySoftDeleteAsync([FromRoute] long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException("shecdoma gvaqvs");
                }
                var res = await ser.SoftDeleteAsync(id, new CategoryModel() { TransactionTypeID=0,TransactionCategory = "UNDEFINED" });
                return res == true ? Ok(res) : BadRequest("No  data exist on this Id");
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("transactiontype/{id:long}/softdelete")]
        public async Task<IActionResult> TransactionTypeSoftDeleteAsync([FromRoute] long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException("shecdoma gvaqvs");
                }
                var res = await ser.SoftDeleteAsync(id, new TransactionTypeModel() { TransactionName = "UNDEFINED" });
                return res == true ? Ok(res) : BadRequest("No  data exist on this Id");
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPut]
        [Route("chanell/{id:long}/update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] ChanellModel entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException("shecdoma gvaqvs");
                }
                var res = await ser.UpdateAsync(id,entity);
                return res == true ? Ok(res) : BadRequest("No  data exist on this Id");
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPut]
        [Route("category/{id:long}/update")]
        public async  Task<IActionResult> UpdateAsync([FromRoute]long id, [FromBody]CategoryModel entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException("shecdoma gvaqvs");
                }
                var res = await ser.UpdateAsync(id, entity);
                return res == true ? Ok(res) : BadRequest("No  data exist on this Id");
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }

        [HttpPut]
        [Route("transactiontype/{id:long}/update")]
        public async Task<IActionResult> UpdateAsync([FromRoute]long id, [FromBody]TransactionTypeModel entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException("shecdoma gvaqvs");
                }
                var res = await ser.UpdateAsync(id, entity);
                return res == true ? Ok(res) : BadRequest("No  data exist on this Id");
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message, exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }
    }
}
