﻿using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Interfaces;
using Optio.Core.Entities;
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

    
        public async Task<bool> AddAsync(Category entity)
        {
            try
            {

                var category = await categoriesOfTransactionRepos.SingleOrDefaultAsync(i=>i.TransactionCategory == entity.TransactionCategory);
                if (category == null)
                {
                    if (await context.Types.AnyAsync(io => io.Id == entity.TransactionTypeID))
                    {
                        await categoriesOfTransactionRepos.AddAsync(entity);
                        await context.SaveChangesAsync();
                        return true;
                    }
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

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                string cash = "All category";
                await Task.Delay(1);
                IEnumerable<Category> category = cacheService.GetOrCreate(
                    cash, () =>
                    {
                        return categoriesOfTransactionRepos.Include(io=>io.typeOfTransaction).AsNoTracking().ToList() ??
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

        public async Task<Category> GetByIdAsync(long id)
        {
            try
            {
                string cashkey= "category by id";
                await Task.Delay(1);
                Category category = cacheService.GetOrCreate(
                    cashkey,() => {
                     return   context.CategoryOfTransactions.Include(io=>io.typeOfTransaction)
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

        public async Task<IEnumerable<Category>> GetAllActiveAsync()
        {
            try
            {
                var cat = await categoriesOfTransactionRepos.Include(io=>io.typeOfTransaction).AsNoTracking().Where(i => i.IsActive == true).ToListAsync();
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

        public async Task<bool> RemoveAsync(Category entity)
        {
            try
            {
                var category = await categoriesOfTransactionRepos.SingleOrDefaultAsync(i => i.TransactionCategory == entity.TransactionCategory);
                var typeoftrans = await context.Types.SingleOrDefaultAsync(i=>i.Id== entity.TransactionTypeID);
                if (category is null || typeoftrans is null)
                {
                    throw new InvalidOperationException("There is no such category||there is no type");
                }
                else
                {
                    categoriesOfTransactionRepos.Remove(category);
                    context.SaveChanges();
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


        public async Task<bool> UpdateAsync(long id,Category entity)
        {
            try
            {
                var category = await categoriesOfTransactionRepos.SingleOrDefaultAsync(i => i.Id == id);
                if (category == null)
                {
                    throw new InvalidOperationException("There is no such category");
                }
                else
                {
                    category.TransactionCategory = entity.TransactionCategory;
                    category.TransactionTypeID = entity.TransactionTypeID;
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
