using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace RGBA.Optio.Core.Repositories.UserRelate
{
    public class CustomRoleManager : RoleManager<IdentityRole>
    {
        public CustomRoleManager(IRoleStore<IdentityRole> store, IEnumerable<IRoleValidator<IdentityRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<IdentityRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }

     
    }
}
