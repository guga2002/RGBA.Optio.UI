using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RGBA.Optio.Core.Entities;
using RGBA.Optio.Domain.Custom_Exceptions;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Models;
using RGBA.Optio.Domain.Models.RequestModels;
using RGBA.Optio.Domain.Services.Outer_Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace RGBA.Optio.Domain.Services
{
    public class AdminPanelService : IAdminPanelService
    {
        private readonly RoleManager<IdentityRole> role;
        private readonly SignInManager<User> signin;
        private readonly UserManager<User> userManager;
        private readonly IMapper map;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SmtpService smtp;
        public AdminPanelService(IHttpContextAccessor _httpContextAccessor, IMapper map, SignInManager<User> signin, UserManager<User> userManager,RoleManager<IdentityRole> rol, SmtpService smtp)
        {
            this.signin = signin;
            this.userManager = userManager;
            role = rol;
            this.map = map;
            this._httpContextAccessor = _httpContextAccessor;
            this.smtp = smtp;
        }

        public async Task<IdentityResult> AddRolesAsync(string RoleName)
        {
            try
            {
                if(string.IsNullOrEmpty(RoleName)||RoleName.Length<=3)
                {
                    throw new OptioGeneralException(RoleName);
                }
                var res = await role.CreateAsync(new IdentityRole(RoleName));
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IdentityResult> AssignRoleToUserAsync(string UserId, string Role)
        {
            try
            {
                if (await role.RoleExistsAsync(Role))
                {
                    var res = userManager.Users.Where(io => io.Id == UserId).FirstOrDefault();
                    if (res is null)
                    {
                        return new IdentityResult();
                    }
                    var rek = await userManager.AddToRoleAsync(res, Role);
                    return rek;
                }
                return new IdentityResult();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> ConfirmEmail(string Email, string Username)
        {
            throw new NotImplementedException();
            //will store  email confirmation logic
        }

        public async Task<IdentityResult> DeleteRole(string rol)
        {
            try
            {
                if(await role.RoleExistsAsync(rol))
                {
                    var res = await role.DeleteAsync(new IdentityRole(rol));
                    return res;
                }
                return new IdentityResult();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IdentityResult> DeleteUser(string id)
        {
            var res = userManager.Users.FirstOrDefault(io => io.Id == id);
            if(res is not null)
            {
                var rek=await userManager.DeleteAsync(res);
                return rek;
            }
            return new IdentityResult();
        }

        public Task<bool> ForgetPassword(string Email)
        {
            throw new NotImplementedException();
            //will send  link yo user to reset password if user exist
        }

        public async Task<UserModel> Info(string Username)
        {
            try
            {
                var res = await userManager.Users.FirstOrDefaultAsync(io => io.UserName == Username);
                if (res is not null)
                {
                    var mapped = map.Map<UserModel>(res);
                    return mapped;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> RefreshToken(string Username, string token)
        {
            var user = await userManager.FindByNameAsync(Username);
            if (user == null)
            {
                return false;
            }

            var isValidToken = await signin.UserManager.VerifyUserTokenAsync(user, userManager.Options.Tokens.PasswordResetTokenProvider, "RefreshToken", token);
            if (!isValidToken)
            {
                return false;
            }

            var result = await signin.UpdateExternalAuthenticationTokensAsync(new ExternalLoginInfo(new System.Security.Claims.ClaimsPrincipal(),"JWT Bearer", "65E255FF-F399-42D4-9C7F-D5D08B0EC285","Auth")
            {
                ProviderKey = user.Id,
                AuthenticationTokens = new AuthenticationToken[]
                {
                new AuthenticationToken { Name = "access_token", Value = token },
                }
            });

            return result.Succeeded;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserModel User, string Password)
        {
            try
            {

                if (await userManager.FindByEmailAsync(User.Email) is null)
                {
                    var maped = map.Map<User>(User);
                    var res = await userManager.CreateAsync(maped, Password);
                    if(res.Succeeded)
                    return res;

                    throw new ArgumentException("somethings unucual");
                  
                }
                throw new ArgumentException(" User already exist in db");
            }
            catch (Exception)
            {
                throw;
            }
}

        public async Task<IdentityResult> ResetPasswordAsync(PasswordResetModel arg, string username)
        {
            var res =await userManager.FindByNameAsync(username);
            if(res is not null)
            {
               var rek=await userManager.ChangePasswordAsync(res, arg.oldPassword, arg.newPassword);
                return rek;
            }
            return new IdentityResult();
        }

        public async Task<(SignInResult, string)> SignInAsync(SignInModel mod)
        {
            if (string.IsNullOrEmpty(mod.Username) || string.IsNullOrEmpty(mod.Password))
            {
                throw new OptioGeneralException("Username or password is empty.");
            }

            var result = await signin.PasswordSignInAsync(mod.Username, mod.Password, mod.SetCookie, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                await SetPersistentCookieAsync(_httpContextAccessor.HttpContext.User);
                var token = GenerateJwtToken(mod.Username);
                await Console.Out.WriteLineAsync(token);
                var usr = await userManager.FindByNameAsync(mod.Username);
                if (usr != null)
                {
                    string recipientName = usr.Name+' '+usr.Surname;
                    string emailContent = $@"
                      <html>
                     <body style='font-family: Arial, sans-serif;'>
                     <p>Dear <span style='color: #3366cc;'>{recipientName}</span>,</p>
                     <p>We noticed a new sign-in to your RGBASOLUTION account. If this was you, there's no need for further action. 
                      However, if you didn't initiate this sign-in, please contact us immediately, and we will assist you in securing your account.</p>
                     <p>Thank you for your attention to this matter.</p>
                     <p style='color: #ff6600;'>Sincerely,<br/>Your RGBASOLUTION Team</p>
                     </body>
                     </html>";

                    smtp.SendMessage(usr.Email, $"Security Alert: New Sign-in to Your RGBASOLUTION Account {DateTime.Now.ToShortTimeString()}", emailContent);
                }
                return (result, token);
            }
            else if (!result.Succeeded && !mod.SetCookie)
            {
                await ClearPersistentCookieAsync();
            }

            return (result, null);
        }
        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
              new Claim(ClaimTypes.Name, username),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KkQl/Fp7eupD0YdLsK+ynGpEZ6g/Y0N6/J4I2V57E8E="));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:44359/",
                audience: "https://localhost:44359/",
                claims: claims,
                expires: DateTime.Now.AddHours(6),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private async Task SetPersistentCookieAsync(ClaimsPrincipal principal)
        {
            await _httpContextAccessor.HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,principal, new AuthenticationProperties { IsPersistent = true });
        }

        private async Task ClearPersistentCookieAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
        }

        public async Task<bool> SignOutAsync()
        {
            try
            {
                await signin.SignOutAsync();
                return true;
            }
            catch (Exception)
            {

                throw;

            }
        }

        public async Task<IEnumerable<RoleModel>> GetAllRoles()
        {
            var res=await role.Roles.Where(io=>io.Name!=null&&io.NormalizedName!=null)
             .Select(io=>new RoleModel
            {
               Name=io.Name,
               NormalizedName=io.NormalizedName,
            }).ToListAsync();
            return res;
        }
        public async Task<IEnumerable<UserModel>> GetAllUser()
        {
            var res =await userManager.Users.Select(io=>new UserModel
            {
                Name= io.Name,
                Email=io.Email,
                Surname=io.Surname,
                Password="***********",
                BirthDate=io.BirthDate,
                PersonalNumber=io.PersonalNumber,
                Username=io.UserName
            }).ToListAsync();

            return res;
        }
    }
}
