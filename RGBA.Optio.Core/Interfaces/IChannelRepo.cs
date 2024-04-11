using Optio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Optio.Core.Interfaces
{
    public interface IChannelRepo : ICrudRepo<Channels,Guid>
    {
        Task<IEnumerable<Channels>> GetAllActiveChannelAsync();
    }
}
