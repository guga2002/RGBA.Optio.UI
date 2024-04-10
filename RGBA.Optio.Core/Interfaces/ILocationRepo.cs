using Optio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optio.Core.Interfaces
{
    public interface ILocationRepo:ICrudRepo<Location, Guid>
    {
        Task<IEnumerable<Location>> GetAllActiveLocationAsync();
    }
}
