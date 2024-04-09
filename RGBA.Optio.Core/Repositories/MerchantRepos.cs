using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Optio.Core.Data;
using Optio.Core.Entities;
using Optio.Core.Interfaces;


namespace Optio.Core.Repositories
{
    public class MerchantRepos : AbstractClass, IMerchantRepo
    {
        private readonly DbSet<Merchant> merchant;

        public MerchantRepos(OptioDB optioDB):base(optioDB)
        {
            merchant = context.Set<Merchant>(); 
        }
      

        public async Task<bool> Add(Merchant entity)
        {
            try
            {
                var obj = merchant.SingleOrDefaultAsync(i => i.Name.ToLower() == entity.Name.ToLower());
                if (obj == null)
                {
                    await merchant.AddAsync(entity);
                    await context.SaveChangesAsync();
                    return true;
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

        public async Task<IEnumerable<Merchant>> GetAll()
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

        public async Task<IEnumerable<Merchant>> GetAllActiveMerchant()
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

        public async Task<Merchant> GetById(Guid id)
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

        public async Task<bool> Remove(Merchant entity)
        {
            try
            {
                var store = await merchant.SingleOrDefaultAsync(i => i.Name.ToLower() == entity.Name.ToLower());
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

        public async Task<bool> SoftDelete(Guid id)
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

        public async Task<bool> Update(Merchant entity)
        {
            try
            {
                var store = await merchant.SingleOrDefaultAsync(i => i.Id == entity.Id);
                if (store == null)
                {
                    throw new InvalidOperationException("No merchant found");
                }
                else
                {
                    merchant.Entry(store).CurrentValues.SetValues(entity);
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
