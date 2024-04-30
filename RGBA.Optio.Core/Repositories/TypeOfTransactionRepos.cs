using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Entities;
using Optio.Core.Interfaces;
using System.Numerics;

namespace Optio.Core.Repositories
{
    public class TypeOfTransactionRepos : AbstractClass, ITypeOfTransactionRepo
    {
        private readonly DbSet<TypeOfTransaction> TypeOfTransaction;

        public TypeOfTransactionRepos(OptioDB optioDB) : base(optioDB)
        {
            TypeOfTransaction=context.Set<TypeOfTransaction>();
        }

        public async Task<long> AddAsync(TypeOfTransaction entity)
        {
            try
            {
                if (!await TypeOfTransaction.AnyAsync(io => io.TransactionName == entity.TransactionName))
                {
                    await TypeOfTransaction.AddAsync(entity);
                    await context.SaveChangesAsync();
                    var max = await TypeOfTransaction.MaxAsync(io => io.Id);
                    return max;
                }
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TypeOfTransaction>> GetAllAsync()
        {
            try
            {
                return await TypeOfTransaction.
                     AsNoTracking()
                     .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TypeOfTransaction>> GetAllActiveTypeOfTransactionAsync()
        {
            try
            {
                return await TypeOfTransaction.
                     AsNoTracking().
                     Where(io => io.IsActive)
                     .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TypeOfTransaction> GetByIdAsync(long id)
        {
            return await (from typ in TypeOfTransaction
                    where typ.Id == id && typ.IsActive
                    select typ).AsNoTracking()
                    .FirstOrDefaultAsync()
                    ??throw new ArgumentException(" No exist  type on this Id");
        }

        public async Task<bool> RemoveAsync(TypeOfTransaction entity)
        {
            try
            {
                var typ = await TypeOfTransaction.AsNoTracking().FirstOrDefaultAsync(io => io.Id == entity.Id);
                if (typ is not null)
                {
                    TypeOfTransaction.Remove(typ);
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

        public async Task<bool> SoftDeleteAsync(long id)
        {
            try
            {
                var typ = await TypeOfTransaction
                    .AsNoTracking()
                    .FirstOrDefaultAsync(io => io.Id == id && io.IsActive);

                if (typ is not null)
                {
                    typ.IsActive = false;
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

        public async Task<bool> UpdateAsync(long id, TypeOfTransaction entity)
        {
            try
            {
                var existingEntity = await TypeOfTransaction.AsNoTracking().FirstOrDefaultAsync(io => io.Id == id);
                if (existingEntity != null)
                {
                    context.Entry(existingEntity).CurrentValues.SetValues(entity);
                    try
                    {
                        await context.SaveChangesAsync();
                        return true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        var entry = ex.Entries.Single();
                        var clientValues = (TypeOfTransaction)entry.Entity;
                        entry.CurrentValues.SetValues(clientValues);
                        throw;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
