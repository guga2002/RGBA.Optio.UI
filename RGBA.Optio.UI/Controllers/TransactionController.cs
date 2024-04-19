using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Models;
using RGBA.Optio.Domain.Services;
using ZstdSharp.Unsafe;

namespace RGBA.Optio.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;
        private readonly ILogger logger;
        private readonly IMemoryCache memoryCache;

        public TransactionController(ITransactionService transactionService, ILogger logger, IMemoryCache memoryCache)
        {
            this.transactionService = transactionService;
            this.logger = logger;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                string cachekey = "GetAllTransaction";
                if(ModelState.IsValid)
                {
                    if(memoryCache.TryGetValue(cachekey,out IEnumerable<TransactionModel>? value))
                    {
                        return Ok(value);
                    }
                    else
                    {
                        var res = await transactionService.GetAllAsync(new TransactionModel 
                        { Amount=0,
                          CategoryId=new Guid(),
                          ChannelId=new Guid(),
                          MerchantId=new Guid(),
                          CurencyNameId=0,
                          Date=new DateTime(),
                          EquivalentInGel=0 
                        });

                        if (!res.Any())
                        {
                            return NotFound();
                        }
                        memoryCache.Set(cachekey,res,TimeSpan.FromMinutes(20));
                        return Ok(res);
                    }
                }
               return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message,ex.StackTrace,DateTime.Now.ToShortTimeString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AllActive()
        {
            try
            {
                string cacheKey = "AllActiveTransaction";
                if (ModelState.IsValid)
                {
                    if(memoryCache.TryGetValue(cacheKey,out IEnumerable<TransactionModel>? value))
                    {
                        return Ok(value);
                    }
                    else
                    {
                        var res=await transactionService.GetAllActiveAsync(new TransactionModel
                        {
                            Amount = 0,
                            CategoryId = new Guid(),
                            ChannelId = new Guid(),
                            MerchantId = new Guid(),
                            CurencyNameId = 0,
                            Date = new DateTime(),
                            EquivalentInGel = 0
                        });
                        if(res is null)
                        {
                            return NotFound();
                        }
                        memoryCache.Set(res,cacheKey,TimeSpan.FromMinutes(20));
                        return Ok(res);
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message,ex.StackTrace,DateTime.Now.ToShortTimeString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult>Get(Guid id)
        {
            try
            {
                string cachekey = $"TransactionById: {id}";
                if (ModelState.IsValid)
                {
                    if(memoryCache.TryGetValue(cachekey,out var value))
                    {
                        return Ok(value);
                    }
                    else
                    {
                        var res = await transactionService.GetByIdAsync(id, new TransactionModel
                        {
                            Amount = 0,
                            CategoryId = new Guid(),
                            ChannelId = new Guid(),
                            MerchantId = new Guid(),
                            CurencyNameId = 0,
                            Date = new DateTime(),
                            EquivalentInGel = 0
                        });
                        if(res is null)
                        {
                            return NotFound();
                        }
                        memoryCache.Set(cachekey, res, TimeSpan.FromMinutes(20));
                        return Ok(res);
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]TransactionModel model)
        {
            try
            {
                if (ModelState.IsValid && model is not null)
                {
                    var res=await transactionService.AddAsync(model);
                    if (res)
                    {
                        return Ok(res);
                    }
                    return StatusCode(405);
                }
                return BadRequest(model);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("transaction")]
        public async Task<IActionResult> Delete([FromBody]TransactionModel model)
        {
            try
            {
                if(ModelState.IsValid && model is not null)
                {
                    var res= await transactionService.RemoveAsync(model);
                    return res==true ? Ok(model):BadRequest(model);
                }
                return BadRequest(model);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete([FromBody]Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res =await transactionService.SoftDeleteAsync(id, new TransactionModel
                    {
                        Amount = 0,
                        CategoryId = new Guid(),
                        ChannelId = new Guid(),
                        MerchantId = new Guid(),
                        CurencyNameId = 0,
                        Date = new DateTime(),
                        EquivalentInGel = 0
                    });
                    if (res)
                    {
                        return Ok(res);
                    }
                    return StatusCode(405);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Transaction/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]TransactionModel transactionModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res=await transactionService.UpdateAsync(id, transactionModel);
                    if (res)
                    {
                        return Ok(res);
                    }
                    return StatusCode(405);
                }
                return BadRequest(transactionModel);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                return BadRequest(ex.Message);
            }
        }



    }
}
