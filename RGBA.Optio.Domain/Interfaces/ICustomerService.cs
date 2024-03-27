using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> RegisterUser(UserModel User, string Password);
        Task<bool> SignIn(string Username, string Password);
        Task<bool> AddRoles(string RoleName);
        Task<bool> AssignRoleToUser(string UserId, string Role);
        Task<bool> ResetPassword(string UserId, string OldPassword, string NewPassword);
        Task<bool> SignOut();
    }
}
