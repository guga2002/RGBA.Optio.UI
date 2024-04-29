using Optio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Optio.Core.Interfaces
{
    public interface ILocationRepo:ICrudRepo<Location, long>
    {
        Task<IEnumerable<Location>> GetAllActiveLocationAsync();
    }
}
