using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Custom_Exceptions
{
    public class InvalidOperationException:Exception
    {
        public InvalidOperationException() { }

        public InvalidOperationException(string message) : base(message) { }

        public InvalidOperationException(string message, Exception exception) : base(message, exception) { }
    }
}
