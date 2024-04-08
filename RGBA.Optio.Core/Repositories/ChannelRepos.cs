using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Optio.Core.Data;
using Optio.Core.Entities;
using Optio.Core.Interfaces;
using SharpCompress.Common;

namespace Optio.Core.Repositories
{
    public class ChannelRepos :AbstractClass, IChannel
    {
      
        private readonly DbSet<Channels> channels;

        public ChannelRepos(OptioDB optioDB):base(optioDB)
        {
            channels = optioDB.Set<Channels>();
        }
     

        public async Task<bool> Add(Channels entity)
        {
            try
            {
                 var channel= await channels.AnyAsync(i=>i.ChannelType==entity.ChannelType);
                if (!channel)
                {
                    await channels.AddAsync(entity);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("A similar channel already exists");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<Channels>> GetAll()
        {
            try
            {
                if (channels.IsNullOrEmpty())
                {
                    throw new InvalidOperationException($"{nameof(channels)} is  empty");
                }
                return await channels.AsNoTracking().ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<Channels>> GetAllActiveChannel()
        {
            try
            {
                var channel = await channels.AsNoTracking().Where(i => i.IsActive == true).ToListAsync();
                if (channel == null)
                {
                    throw new InvalidOperationException("No active channel found");
                }
                else
                {
                    return channel;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Channels> GetById(Guid id)
        {
            try
            {
                var channel = await channels.AsNoTracking().SingleOrDefaultAsync(i => i.Id == id);
                if (channel == null)
                {
                    throw new InvalidOperationException($"Channel not found with ID: {id}");
                }
                return channel;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> Remove(Channels entity)
        {
            try
            {
                var channel = await channels.AnyAsync(i => i.ChannelType == entity.ChannelType);
                if (channel)
                {
                    channels.Remove(entity);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("No similar channel found");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> SoftDelete(Guid id)
        {
            try
            {
                var channel = await channels.SingleOrDefaultAsync(i => i.Id == id);
                if (channel != null)
                {
                    channel.IsActive = false;
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("No similar channel found");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> Update(Channels entity)
        {
            try
            {
                var channel = await channels.SingleOrDefaultAsync(i => i.ChannelType == entity.ChannelType);
                if (channel != null)
                {
                    channel.IsActive = entity.IsActive;
                    channel.ChannelType = entity.ChannelType;
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("No similar channel found");
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
