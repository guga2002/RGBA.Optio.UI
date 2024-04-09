using Microsoft.AspNetCore.Identity;
using Optio.Core.Data;
using Optio.Core.Repositories;
using RGBA.Optio.Core.Entities;
using RGBA.Optio.Core.Interfaces;

namespace RGBA.Optio.Core.Repositories
{
    public class UserRepository :AbstractClass, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(OptioDB db,UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> role):base(db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = role;
        }

        public async Task<bool> AddRolesAsync(string RoleName)
        {
            try
            {
                var res = await _roleManager.RoleExistsAsync(RoleName.ToUpper());
                if (!res)
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleName));
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async  Task<bool> AssignRoleToUserAsync(string UserId, string Role)
        {
            try
            {
                var res = context.Users.Where(io => io.Id == UserId).FirstOrDefault();
                if (res != null)
                {
                    if (await _roleManager.RoleExistsAsync(Role))
                    {
                        await _userManager.AddToRoleAsync(res, Role);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RegisterUserAsync(User User, string Password)
        {
            try
            {
                var res = await _userManager.AddPasswordAsync(User, Password);
                if (res.Succeeded)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ResetPasswordAsync(string UserId,string OldPassword, string NewPassword)
        {
            try
            {
                var res = context.Users.Where(io => io.Id == UserId).FirstOrDefault();
                if (res != null)
                {
                    await _userManager.ChangePasswordAsync(res, OldPassword, NewPassword);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SignInAsync(string Username, string Password)
        {
            try
            {
                var res = await _signInManager.PasswordSignInAsync(Username, Password, false, false);
                if (res.Succeeded)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SignOutAsync()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
