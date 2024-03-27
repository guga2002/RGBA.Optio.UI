using Optio.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optio.Core.Repositories
{
    public abstract class AbstractClass
    {
        protected readonly OptioDB context;
        protected AbstractClass(OptioDB optioDB)
        {
            context = optioDB;
        }
    }

}
