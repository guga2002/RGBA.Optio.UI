using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Entities;
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
            return await currencies.AsNoTracking().Where(io=>io.IsActive).ToListAsync();
        }

        public async Task<Currency> GetByIdAsync(int id)
        {
            try
            {
                var result = await currencies.AsNoTracking().FirstOrDefaultAsync(io => io.Id == id && io.IsActive);
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
                var res = await currencies.AsNoTracking().FirstOrDefaultAsync(io => io.Id == entity.Id);
                if (res is not null)
                {
                    currencies.Remove(res);
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

        public async Task<bool> SoftDeleteAsync(int id)
        {
            try
            {
                var res = await currencies.AsNoTracking().FirstOrDefaultAsync(io => io.Id == id);
                if (res is not null)
                {
                    res.IsActive = false;
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

        public async Task<bool> UpdateAsync(int id, Currency entity)
        {
            try
            {
                var res = await currencies.AsNoTracking().FirstOrDefaultAsync(io => io.Id == id);
                if (res is not null)
                {
                    context.Entry(res).CurrentValues.SetValues(entity);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var databaseValues = (TypeOfTransaction)entry.GetDatabaseValues().ToObject();
                entry.CurrentValues.SetValues(databaseValues);
                throw;
            }
        }
    }
}
