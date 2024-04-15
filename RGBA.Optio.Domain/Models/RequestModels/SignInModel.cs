using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Models.RequestModels
{
    public class SignInModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool SetCookie { get; set; }
    }
}
