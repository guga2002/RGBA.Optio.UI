using RGBA.Optio.Core.Entities;

namespace RGBA.Optio.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> RegisterUser(User User,string Password);
        Task<bool> SignIn(string Username, string Password);
        Task<bool> AddRoles(string RoleName);
        Task<bool> AssignRoleToUser(string UserId, string Role);
        Task<bool> ResetPassword(string UserId, string OldPassword, string NewPassword);
        Task<bool> SignOut();
    }
}
