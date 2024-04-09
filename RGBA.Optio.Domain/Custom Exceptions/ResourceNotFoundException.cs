using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Custom_Exceptions
{
    public class ResourceNotFoundException:Exception
    {
        public ResourceNotFoundException() { }

        public ResourceNotFoundException(string message) : base(message) { }

        public ResourceNotFoundException(string message, Exception exception) : base(message, exception) { }
    }
}
