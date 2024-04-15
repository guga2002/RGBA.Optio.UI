﻿using Microsoft.AspNetCore.Identity;
using RGBA.Optio.Domain.Models;
using RGBA.Optio.Domain.Models.RequestModels;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface IAdminPanelService
    {
        Task<IdentityResult> DeleteRole(string role);
        Task<UserModel> Info(string Username);
        Task<bool> ForgetPassword(string Email);
        Task<bool> RefreshToken(string Username,string token);
        Task<IdentityResult> RegisterUserAsync(UserModel User, string Password);
        Task<(SignInResult, string)> SignInAsync(SignInModel mod);
        Task<IdentityResult> AddRolesAsync(string RoleName);
        Task<IdentityResult> AssignRoleToUserAsync(string UserId, string Role);
        Task<IdentityResult> ResetPasswordAsync(PasswordResetModel arg,string username);
        Task<bool> SignOutAsync();
        Task<IdentityResult> DeleteUser(string id);
        Task<bool> ConfirmEmail(string Email, string Username);
        Task<IEnumerable<RoleModel>> GetAllRoles();
        Task<IEnumerable<UserModel>> GetAllUser();
    }
}
