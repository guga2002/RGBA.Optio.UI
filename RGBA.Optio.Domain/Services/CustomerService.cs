using AutoMapper;
using Microsoft.Extensions.Logging;
using RGBA.Optio.Core.Interfaces;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.Domain.Services
{
    public class CustomerService : AbstractService<CustomerService>, ICustomerService
    {
        public CustomerService(IUniteOfWork work, IMapper map, ILogger<CustomerService> log) : base(work, map, log)
        {
        }

        public Task<bool> AddRoles(string RoleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AssignRoleToUser(string UserId, string Role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUser(UserModel User, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPassword(string UserId, string OldPassword, string NewPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SignIn(string Username, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
