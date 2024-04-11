using AutoMapper;
using Microsoft.Extensions.Logging;
using RGBA.Optio.Core.Interfaces;
using RGBA.Optio.Core.Repositories.UserRelate;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.Domain.Services
{
    public class AdminPanelService : IAdminPanelService
    {
        private readonly CustomRoleManager role;
        private readonly CustomSignInManager signin;
        private readonly CustomUserManager userManager;
        public AdminPanelService(CustomSignInManager signin, CustomUserManager userManager,CustomRoleManager rol)
        {
            this.signin = signin;
            this.userManager = userManager;
            role = rol;
        }

        public Task<bool> AddRolesAsync(string RoleName)
        {
            throw new NotImplementedException();
           
        }

        public Task<bool> AssignRoleToUserAsync(string UserId, string Role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUserAsync(UserModel User, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPasswordAsync(string UserId, string OldPassword, string NewPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SignInAsync(string Username, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SignOutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
