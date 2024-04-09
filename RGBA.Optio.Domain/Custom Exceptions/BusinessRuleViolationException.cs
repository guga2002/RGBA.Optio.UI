using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Custom_Exceptions
{
    public class BusinessRuleViolationException:Exception
    {
        public BusinessRuleViolationException() { }

        public BusinessRuleViolationException(string message):base(message) { }

        public BusinessRuleViolationException(string message,Exception exception) : base(message,exception) { }
        
    }
}
