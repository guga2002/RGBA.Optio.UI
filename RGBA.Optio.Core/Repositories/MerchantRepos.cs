using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Entities;
using Optio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optio.Core.Repositories
{
    public class MerchantRepos : AbstractClass, IMerchantRepo
    {
        private readonly DbSet<Merchant> merchant;

        public MerchantRepos(OptioDB optioDB):base(optioDB)
        {
            merchant = context.Set<Merchant>(); 
        }
      

        public Task<bool> Add(Entities.Merchant entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entities.Merchant>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Merchant> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Entities.Merchant entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Entities.Merchant entity)
        {
            throw new NotImplementedException();
        }
    }
}
