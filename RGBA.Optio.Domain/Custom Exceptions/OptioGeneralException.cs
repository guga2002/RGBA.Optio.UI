using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Custom_Exceptions
{
    public class OptioGeneralException:Exception
    {
        public OptioGeneralException() { }

        public OptioGeneralException(string message) : base(message) { }

        public OptioGeneralException(string message, Exception exception) : base(message, exception) { }
    }
}
