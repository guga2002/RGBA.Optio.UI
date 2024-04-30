using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Optio.Core.Data;
using Optio.Core.Entities;
using Optio.Core.Interfaces;
using RGBA.Optio.Core.Entities;


namespace Optio.Core.Repositories
{
    public class MerchantRepos : AbstractClass, IMerchantRepo
    {
        private readonly DbSet<Merchant> merchant;

        public MerchantRepos(OptioDB optioDB):base(optioDB)
        {
            merchant = context.Set<Merchant>(); 
        }
      
        public async Task<bool> AssignLocationtoMerchant(long Merchantid,long Locationid)
        {
            try
            {
                if(await merchant.AnyAsync(io=>io.Id==Merchantid)&&await context.Locations.AnyAsync(io=>io.Id==Locationid))
                {
                    await context.LoactionTomerchant.AddAsync(new LocationToMerchant()
                    {
                        LocatrionId = Locationid,
                        merchantId = Merchantid,
                    });
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<long> AddAsync(Merchant entity)
        {
            try
            {
                var obj = await merchant.SingleOrDefaultAsync(i => i.Name == entity.Name);
                if (obj == null)
                {
                    await merchant.AddAsync(entity);
                    await context.SaveChangesAsync();
                    var max = await merchant.MaxAsync(io => io.Id);
                    return max;
                }
                else
                {
                    throw new InvalidOperationException("Such a merchant already exists");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Merchant>> GetAllAsync()
        {
            try
            {
                if (merchant.IsNullOrEmpty())
                {
                    throw new InvalidOperationException("No merchants found");
                }
                else
                {
                    return await merchant
                        .AsNoTracking()
                        .ToListAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Merchant>> GetAllActiveMerchantAsync()
        {
            try
            {
                var store = await merchant.AsNoTracking().Where(i => i.IsActive == true).ToListAsync();
                if (store == null)
                {
                    throw new InvalidOperationException("No active merchants found");
                }
                else
                {
                    return store;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Merchant> GetByIdAsync(long id)
        {
            try
            {
                var store = await merchant.AsNoTracking().SingleOrDefaultAsync(i => i.Id == id);
                if (store == null)
                {
                    throw new InvalidOperationException("No merchant found");
                }
                else
                {
                    return store;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> RemoveAsync(Merchant entity)
        {
            try
            {
                var store = await merchant.SingleOrDefaultAsync(i => i.Name.ToLower()==entity.Name.ToLower());
                if (store == null)
                {
                    throw new InvalidOperationException("No merchant found");
                }
                else
                {
                    merchant.Remove(store);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SoftDeleteAsync(long id)
        {
            try
            {
                var store=await merchant.SingleOrDefaultAsync(i=>i.Id==id);
                if (store == null)
                {
                    throw new InvalidOperationException("No merchant found");
                }
                else
                {
                    store.IsActive = false;
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(long id, Merchant entity)
        {
            try
            {
                var store = await merchant.SingleOrDefaultAsync(i => i.Id == id);
                if (store == null)
                {
                    throw new InvalidOperationException("No merchant found");
                }
                else
                {
                    store.Name = entity.Name;
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
