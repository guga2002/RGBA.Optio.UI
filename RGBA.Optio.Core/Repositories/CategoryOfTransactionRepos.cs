using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Interfaces;
using Optio.Core.Entities;
using DnsClient.Protocol;

namespace Optio.Core.Repositories
{
    public class CategoryOfTransactionRepos : AbstractClass, ICategoryRepo
    {
        private readonly DbSet<Category> categoriesOfTransactionRepos;

        public CategoryOfTransactionRepos(OptioDB optioDB):base(optioDB)
        {
            categoriesOfTransactionRepos = context.Set<Category>();
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


        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                var entities = await categoriesOfTransactionRepos.AsNoTracking().ToListAsync();
                if (entities.Any())
                {
                    return entities;
                }
               else return Enumerable.Empty<Category>();

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Category> GetById(Guid id)
        {
            try
            {
                var category = await categoriesOfTransactionRepos.AsNoTracking().SingleOrDefaultAsync(i => i.Id == id);
                if(category == null)
                {
                    throw new InvalidOperationException($"Category with ID {id} was not found.");
                }
                    return category;
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
                    category.TransactionCategory = entity.TransactionCategory;
                    category.IsActive = entity.IsActive;
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
