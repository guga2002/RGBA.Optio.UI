using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Entities;
using Optio.Core.Interfaces;
using RGBA.Optio.Core.PerformanceImprovmentServices;

namespace Optio.Core.Repositories
{
    public class ChannelRepos :AbstractClass,IChannelRepo
    {
      
        private readonly DbSet<Channels> channels;
        private readonly CacheService cacheService;

        public ChannelRepos(OptioDB optioDB, CacheService cacheService) :base(optioDB)
        {
            channels = optioDB.Set<Channels>();
            this.cacheService = cacheService;
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


        Func<OptioDB, IEnumerable<Channels>> CompiledQueryGetAll =
            EF.CompileQuery(
                (OptioDB db) =>
                db.Channels.ToList()
                );

        public async Task<IEnumerable<Channels>> GetAll()
        {
            try
            {
                string cachekey = "all channels";
                await Task.Delay(1);
                IEnumerable<Channels> ch = cacheService.GetOrCreate(cachekey, () =>
                    {
                        return CompiledQueryGetAll.Invoke(context) ??
                        throw new ArgumentException("No channel found");
                    }, TimeSpan.FromMinutes(30)); 
                return ch ?? throw new ArgumentException("No channel found");
            }
            catch (Exception)
            {
                throw;
            }
        }


        Func<OptioDB, IEnumerable<Channels>?> CompiledQueryGetAllActiveChannel =
            EF.CompileQuery(
                (OptioDB db) =>
                db.Channels
                .Where(i=>i.IsActive==true)
                .ToList()
                );

        public async Task<IEnumerable<Channels>> GetAllActiveChannel()
        {
            try
            {
                string cacheKey = "All Channels";
                await Task.Delay(1);
               IEnumerable<Channels> ch = cacheService.GetOrCreate(cacheKey, () =>
                {
                    return CompiledQueryGetAllActiveChannel.Invoke(context) ??
                    throw new ArgumentException("No active channel found");
                }, TimeSpan.FromMinutes(30)
                    );
                return ch ?? throw new ArgumentException("No active channel found");
            }
            catch (Exception)
            {
                throw;
            }
        }


        Func<OptioDB, Guid, Channels?> CompiledQueryGetBtId =
            EF.CompileQuery(
                (OptioDB db, Guid id) =>
                db.Channels.SingleOrDefault(i=>i.Id==id)
                );
        public async Task<Channels> GetById(Guid id)
        {
            try
            {
                string cacheKey = $"channel with {id}";
                await Task.Delay(1);
                Channels channel = cacheService.GetOrCreate(cacheKey, () =>
                {
                    return CompiledQueryGetBtId.Invoke(context, id) ??
                    throw new ArgumentException("No channel found");
                }, TimeSpan.FromMinutes(15));

                return channel ?? throw new ArgumentException("No channel found");

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
                    context.Entry(channel).CurrentValues.SetValues(entity);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("No similar channel found");
                }

            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch(Exception )
            {
                throw;
            }

        }
    }
}
