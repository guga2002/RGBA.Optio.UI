using RGBA.Optio.Core.Entities;

namespace RGBA.Optio.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> RegisterUserAsync(User User,string Password);
        Task<bool> SignInAsync(string Username, string Password);
        Task<bool> AddRolesAsync(string RoleName);
        Task<bool> AssignRoleToUserAsync(string UserId, string Role);
        Task<bool> ResetPasswordAsync(string UserId, string OldPassword, string NewPassword);
        Task<bool> SignOutAsync();
    }
}
