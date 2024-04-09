using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> RegisterUserAsync(UserModel User, string Password);
        Task<bool> SignInAsync(string Username, string Password);
        Task<bool> AddRolesAsync(string RoleName);
        Task<bool> AssignRoleToUserAsync(string UserId, string Role);
        Task<bool> ResetPasswordAsync(string UserId, string OldPassword, string NewPassword);
        Task<bool> SignOutAsync();
    }
}
