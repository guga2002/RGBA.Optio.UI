using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RGBA.Optio.Domain.Custom_Exceptions;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Models;
using RGBA.Optio.Domain.Models.RequestModels;
using System.Net.Http.Headers;

namespace RGBA.Optio.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IAdminPanelService ser;
        private readonly ILogger<CustomerController> log;
        public CustomerController(IAdminPanelService se, ILogger<CustomerController> log)
        {
            this.ser = se;
            this.log = log;

        }
        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody]SignInModel mod)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    throw new OptioGeneralException(mod.Username);
                }
                var res = await ser.SignInAsync(mod);
                if (res.Item2 is not null)
                {
                    return Ok(res.Item2);
                }
                return BadRequest();
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return StatusCode(503, "Internal Server Error");
            }
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Registration([FromBody]UserModel user)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException(user.Username);
                }
                var res = await ser.RegisterUserAsync(user,user.Password);
                return Ok(res);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return StatusCode(503, "Internal Server Error");
            }
        }

        [HttpPost]
        [Route("[action]/{token}")]
        public async Task<IActionResult> RefreshToken([FromQuery] string token)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException(token);
                }
                if (User.Identity is not null && User.Identity.Name is not null&&User.Identity.IsAuthenticated)
                {
                    var res = await ser.RefreshToken(User.Identity.Name,token);
                    return Ok(res);
                }
                else
                {
                    return Unauthorized(new AuthenticationHeaderValue("Bearer"));
                }
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return StatusCode(503, "Internal Server Error");
            }
        }

        [HttpPost]
        [Route("[action]/{Email}")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword([FromQuery] string Email)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException(Email);
                }
                var res = await ser.ForgetPassword(Email);
                return Ok(res);
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return StatusCode(503, "Internal Server Error");
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> ResetPassword([FromBody] PasswordResetModel arg)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException(arg.newPassword);
                }
                if (User is not null&&User.Identity!=null&&User.Identity.Name!=null &&User.Identity.IsAuthenticated)
                {
                    var res = await ser.ResetPasswordAsync(arg, User.Identity.Name);
                    return Ok(res);
                }
                else
                {
                    return Unauthorized(new AuthenticationHeaderValue("Bearer"));
                }
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return StatusCode(503, "Internal Server Errror");
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Info()
        {
            try
            {
                if (User.Identity is not null&&User.Identity.Name is not null&&User.Identity.IsAuthenticated)
                {
                    var res = await ser.Info(User.Identity.Name);
                    return Ok(res);
                }
                else
                {
                    return Unauthorized(new AuthenticationHeaderValue("Bearer"));
                }
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return StatusCode(503, "Internal Server Error");
            }
        }
        [HttpPost]
        [Route("[action]/{Email}")]
        public  async Task<IActionResult> ConfirmEmail([FromQuery] string Email)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new OptioGeneralException("info");
                }
                if (User.Identity is not null&&User.Identity.Name!=null&&User.Identity.IsAuthenticated)
                {
                    var res = await ser.ConfirmEmail(Email, User.Identity.Name);
                    return Ok(res);
                }
                else
                {
                    return Unauthorized(new AuthenticationHeaderValue("Bearer"));
                }
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return StatusCode(503, "Internal Server Error");
            }

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Signout()
        {
            try
            {
                if(User.Identity is not null&&User.Identity.IsAuthenticated)
                {
                    var res=await ser.SignOutAsync();
                    return Ok(res);
                }
                return Unauthorized(new AuthenticationHeaderValue("Bearer"));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
