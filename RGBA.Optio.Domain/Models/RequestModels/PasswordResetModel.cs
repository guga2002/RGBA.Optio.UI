using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Models.RequestModels
{
    public class PasswordResetModel
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
