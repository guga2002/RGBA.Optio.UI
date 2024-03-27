using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Interfaces;
using Optio.Core.Entities;

namespace Optio.Core.Repositories
{
    public class CategoryOfTransactionRepos : AbstractClass, ICategoryRepo
    {
        private readonly DbSet<CategoryOfTransactionRepos> categoriesOfTransactionRepos;

        public CategoryOfTransactionRepos(OptioDB optioDB):base(optioDB)
        {
            categoriesOfTransactionRepos= context.Set<CategoryOfTransactionRepos>();
        }

    
        public Task<bool> Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
