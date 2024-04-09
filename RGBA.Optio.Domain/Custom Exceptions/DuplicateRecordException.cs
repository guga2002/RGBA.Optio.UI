using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Custom_Exceptions
{
    public class DuplicateRecordException:Exception
    {
        public DuplicateRecordException() { }

        public DuplicateRecordException(string message) : base(message) { }

        public DuplicateRecordException(string message, Exception exception) : base(message, exception) { }
    }
}
