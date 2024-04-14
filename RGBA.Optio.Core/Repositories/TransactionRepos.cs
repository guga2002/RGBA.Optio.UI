using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Entities;
using Optio.Core.Interfaces;
using RGBA.Optio.Core.PerformanceImprovmentServices;

namespace Optio.Core.Repositories
{
    public class TransactionRepos : AbstractClass, ITransactionRepo
    {
        private readonly DbSet<Transaction> transactions;
        private readonly CacheService _cache;

        public TransactionRepos(OptioDB optioDB, CacheService cache) :base(optioDB)
        {
            transactions=context.Set<Transaction>();
            this._cache = cache;
        }

        public async Task<bool> AddAsync(Transaction entity)
        {
            try
            {
                if (!await context.CategoryOfTransactions.AnyAsync(io => io.Id == entity.CategoryId) ||
                    !await context.Currencies.AnyAsync(io => io.Id == entity.CurrencyId) ||
                     !await context.Locations.AnyAsync(io => io.Id == entity.LocationId) ||
                      !await context.Merchants.AnyAsync(io => io.Id == entity.MerchantId) ||
                       !await context.Types.AnyAsync(io => io.Id == entity.TypeId))
                {
                    throw new ArgumentException("No related Table exist, Please   Recorect your data");
                }
                if (await transactions.AnyAsync(io => io.Id == entity.Id))
                {
                    throw new ArgumentException("Such a Transaction Already Exist In Db");
                }
                await transactions.AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


        Func<OptioDB, IEnumerable<Transaction>> CompiledQUeryGetAll =
            EF.CompileQuery(
                (OptioDB db) =>
                    db.Transactions.AsNoTracking().ToList());

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            try
            {
                    string cacheKey = $"GetAllTransactions";
                    await Task.Delay(1);
                    IEnumerable<Transaction> transactions = _cache.GetOrCreate(cacheKey, () =>
                    {
                        return CompiledQUeryGetAll.Invoke(context);
                    }, TimeSpan.FromMinutes(15));

                    return transactions ?? throw new ArgumentException("No transactions found");
            }
            catch (Exception)
            {
                throw;
            }
        }

        Func<OptioDB, List<Transaction>> CompiledQueryGetAllDetails =
          EF.CompileQuery(
          (OptioDB database)
           =>database.Transactions
            .Include(io=>io.Category)
             .Include(io=>io.Channel)
              .Include(io=>io.Currency)
              .ThenInclude(io=>io.Courses)
              .Include(io=>io.Merchant)
               .Include(io=>io.Location)
                .ToList());

        public async Task<IEnumerable<Transaction>> GetAllWithDetailsAsync()
        {
            try
            {
                string cacheKey = $"GetAllTransactionsWithDetails";
                await Task.Delay(1);
                IEnumerable<Transaction> transactions = _cache.GetOrCreate(cacheKey, () =>
                {
                    return CompiledQueryGetAllDetails.Invoke(context);
                }, TimeSpan.FromMinutes(15));

                return transactions ?? throw new ArgumentException("No transactions found");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Transaction> GetByIdAsync(Guid id)
        {
            try
            {
                string cacheKey = $"Transaction_{id}";
                await Task.Delay(1);
                Transaction transaction = _cache.GetOrCreate(cacheKey, () =>
                {
                    return transactions.AsNoTracking()
                        .Single(io => io.IsActive && io.Id == id);
                }, TimeSpan.FromMinutes(15));

                return transaction ?? throw new ArgumentException("No transaction found");
            }
            catch (Exception)
            {
                throw;
            }
        }

        Func<OptioDB,Guid, Transaction?> CompiledQueryGetBtIdDetails =
        EF.CompileQuery(
        (OptioDB database,Guid id)
         => database.Transactions
          .Include(io => io.Category)
           .Include(io => io.Channel)
            .Include(io => io.Currency)
            .ThenInclude(io => io.Courses)
            .Include(io => io.Merchant)
             .Include(io => io.Location)
              .SingleOrDefault(io=>io.Id==id));

        public async Task<Transaction> GetByIdWithDetailsAsync(Guid ID)
        {
            try
            {
                string cacheKey = $"Transaction_With_detail_{ID}";
                await Task.Delay(1);
                Transaction transaction = _cache.GetOrCreate(cacheKey, () =>
                {
                    return CompiledQueryGetBtIdDetails.Invoke(context, ID)??
                    throw new ArgumentException("No transaction found");
                }, TimeSpan.FromMinutes(15));

                return transaction ?? throw new ArgumentException("No transaction found");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RemoveAsync(Transaction entity)
        {
            try
            {
                if (await transactions.AnyAsync(io => io.Id == entity.Id))
                {
                    var res =await transactions.AsNoTracking().SingleOrDefaultAsync(io => io.Id == entity.Id);
                    if(res!=null)
                    transactions.Remove(res);
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

        public async Task<bool> SoftDeleteAsync(Guid id)
        {
            try
            {
                var res = await transactions.AsNoTracking().SingleOrDefaultAsync(io => io.Id == id);
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

        public async Task<bool> UpdateAsync(Guid id,Transaction entity)
        {
            try
            {
                var tran = await transactions.SingleOrDefaultAsync(io => io.Id == id);
                if (tran is not null)
                {
                    context.Entry(tran).CurrentValues.SetValues(entity);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var en = ex.Entries.Single();
                var value = (Transaction)en.Entity;
                en.CurrentValues.SetValues(value);
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        Func<OptioDB, IEnumerable<Transaction>> CompiledQUeryGetAllActive =
          EF.CompileQuery(
              (OptioDB db) =>
                  db.Transactions.AsNoTracking().ToList());
        public async Task<IEnumerable<Transaction>> GetAllActiveAsync()
        {
            try
            {
                string cacheKey = $"GetAllActiveTransactions";
                await Task.Delay(1);
                IEnumerable<Transaction> transactions = _cache.GetOrCreate(cacheKey, () =>
                {
                    return CompiledQUeryGetAllActive.Invoke(context);
                }, TimeSpan.FromMinutes(15));

                return transactions ?? throw new ArgumentException("No transactions found");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
