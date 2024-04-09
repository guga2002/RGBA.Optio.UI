using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RGBA.Optio.Core.Entities;

namespace RGBA.Optio.Core.Repositories.UserRelate
{
    public class CustomUserManager : UserManager<User>
    {
        public CustomUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }


        public override async Task<IdentityResult> CreateAsync(User user, string password)
        {
            try
            {
                var res =  await this.CreateAsync(user, password);
                if (res.Succeeded)
                {
                    return res;
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
        {
            return base.ResetPasswordAsync(user, token, newPassword);
        }
    }
}
