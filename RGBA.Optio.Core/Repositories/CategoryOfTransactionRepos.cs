using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Interfaces;
using Optio.Core.Entities;
using DnsClient.Protocol;
using DnsClient.Protocol.Options;
using RGBA.Optio.Core.PerformanceImprovmentServices;

namespace Optio.Core.Repositories
{
    public class CategoryOfTransactionRepos : AbstractClass, ICategoryRepo
    {
        private readonly DbSet<Category> categoriesOfTransactionRepos;
        private readonly CacheService cacheService;

        public CategoryOfTransactionRepos(OptioDB optioDB, CacheService cacheService) :base(optioDB)
        {
            categoriesOfTransactionRepos = context.Set<Category>();
            this.cacheService = cacheService;
        }

    
        public async Task<bool> Add(Category entity)
        {
            try
            {
                var category = await categoriesOfTransactionRepos.SingleOrDefaultAsync(i=>i.TransactionCategory == entity.TransactionCategory);
                if (category == null)
                {
                    await categoriesOfTransactionRepos.AddAsync(entity);
                    await context.SaveChangesAsync();
                    return true;
                }
                throw new ArgumentException("There is a similar category");
                
            }
            catch (Exception)
            {

                throw;
            }
        }


      /*  Func<OptioDB, IEnumerable<Category>> CompiledQueryGetAll =
         EF.CompileQuery(
             (OptioDB db) =>
             db.CategoryOfTransactions
             .AsNoTracking()
             .ToList()
            );*/

        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                string cash = "All category";
                await Task.Delay(1);
                IEnumerable<Category> category = cacheService.GetOrCreate(
                    cash, () =>
                    {
                        return categoriesOfTransactionRepos.AsNoTracking().ToList() ??
                        throw new ArgumentException("No category found");
                    }, TimeSpan.FromMinutes(30)
                    ) ;
                 return category ?? throw new ArgumentException("No category found");

            }
            catch (Exception)
            {
                throw;
            }
        }


       /* Func<OptioDB,Guid, Category?> CompiledQueryGetById =
         EF.CompileQuery(
             (OptioDB db,Guid id) =>
             db.CategoryOfTransactions
             .AsNoTracking()
             .SingleOrDefault(i=>i.Id==id)
            );*/

        public async Task<Category> GetById(Guid id)
        {
            try
            {
                string cashkey= "category by id";
                await Task.Delay(1);
                Category category = cacheService.GetOrCreate(
                    cashkey,() => {
                     return   context.CategoryOfTransactions
                    .Single(i => i.Id == id);
                    }
                    ,TimeSpan.FromMinutes(30)
                    );
                return category ?? throw new ArgumentException($"No category by id: {id}");

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<Category>> GetAllActive()
        {
            try
            {
                var cat = await categoriesOfTransactionRepos.AsNoTracking().Where(i => i.IsActive == true).ToListAsync();
                if (cat != null)
                {
                    return cat;
                }
                else
                {
                    throw new InvalidOperationException("No active category founr");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Remove(Category entity)
        {
            try
            {
                var category = await categoriesOfTransactionRepos.Where(i => i.TransactionCategory == entity.TransactionCategory).SingleOrDefaultAsync();
                if (category == null)
                {
                    throw new InvalidOperationException("There is no such category");
                }
                categoriesOfTransactionRepos.Remove(entity);
                context.SaveChanges();
                return true;

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
                var category = await categoriesOfTransactionRepos.SingleOrDefaultAsync(i => i.Id == id);
                if (category == null)
                {
                    throw new InvalidOperationException("There is no such category");
                }
                category.IsActive = false;
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> Update(Category entity)
        {
            try
            {
                var category = await categoriesOfTransactionRepos.SingleOrDefaultAsync(i => i.Id == entity.Id);
                if (category == null)
                {
                    throw new InvalidOperationException("There is no such category");
                }
                else
                {
                    categoriesOfTransactionRepos.Entry(category).CurrentValues.SetValues(entity);
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
