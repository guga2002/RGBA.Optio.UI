using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Entities;
using Optio.Core.Interfaces;

namespace Optio.Core.Repositories
{
    public class ChannelRepos :AbstractClass, IChannel
    {
      
        private readonly DbSet<Channels> channels;

        public ChannelRepos(OptioDB optioDB):base(optioDB)
        {
            channels = optioDB.Set<Channels>();
        }
     

        public Task<bool> Add(Channels entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Channels>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Channels> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Channels entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Channels entity)
        {
            throw new NotImplementedException();
        }
    }
}
