using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using RGBA.Optio.Core.Entities;
using RGBA.Optio.Core.Interfaces;
using System.Data;
using AbstractClass = Optio.Core.Repositories.AbstractClass;

namespace RGBA.Optio.Core.Repositories
{
    public class CurrencyReposiotry : AbstractClass, ICurrencyRepository
    {
        private readonly DbSet<Currency> currencies;
        public CurrencyReposiotry(OptioDB db):base(db)
        {
            currencies = context.Set<Currency>();
        }
        public async Task<bool> AddAsync(Currency entity)
        {
            try
            {
                if (!await currencies.AnyAsync(io => io.NameOfValute == entity.NameOfValute && io.CurrencyCode == entity.CurrencyCode))
                {
                    await currencies.AddAsync(entity);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new ArgumentException("Such Currency already exist!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            return await currencies.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Currency>> GetAllActiveAsync()
        {
            return await currencies.AsNoTracking().Where(io=>io.IsActive == true).ToListAsync();
        }

        public async Task<Currency> GetByIdAsync(int id)
        {
            try
            {
                var result = await currencies.AsNoTracking().FirstOrDefaultAsync(io => io.Id == id && io.IsActive == true);
                if (result is null) throw new ArgumentException("no entoty found!");
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RemoveAsync(Currency entity)
        {
            try
            {
                var res = await currencies.FirstOrDefaultAsync(io => io.NameOfValute == entity.NameOfValute&&io.CurrencyCode==entity.CurrencyCode);
                if (res is not null)
                {
                    currencies.Remove(res);
                    await context.SaveChangesAsync();
                    return true;
                }
                throw new ArgumentException("no such Currency exist");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            try
            {
                var res = await currencies.FirstOrDefaultAsync(io => io.Id == id&&io.IsActive == true);
                if (res is not null)
                {
                    res.IsActive = false;
                    await context.SaveChangesAsync();
                    return true;
                }
                throw new ArgumentException("weeoe,  already the data is  soft deleted or no exist");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(int id, Currency entity)
        {
            try
            {
                var res = await currencies.FirstOrDefaultAsync(io => io.Id == id);
                if (res is not null)
                {
                    res.CurrencyCode= entity.CurrencyCode;
                    res.NameOfValute= entity.NameOfValute;
                    res.IsActive = entity.IsActive;
                    await context.SaveChangesAsync();
                    return true;
                }
                throw new ArgumentException(" no such  currency exist");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
        }
    }
}
