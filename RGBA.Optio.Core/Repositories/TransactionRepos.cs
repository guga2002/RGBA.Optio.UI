using Microsoft.EntityFrameworkCore;
using Optio.Core.Data;
using Optio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Optio.Core.Repositories
{
    public class TransactionRepos : AbstractClass, ITransactionRepo
    {
        private readonly DbSet<Transaction> transactions;

        public TransactionRepos(OptioDB optioDB):base(optioDB)
        {
            transactions=context.Set<Transaction>();
        }

        public Task<bool> Add(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetByIdWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
