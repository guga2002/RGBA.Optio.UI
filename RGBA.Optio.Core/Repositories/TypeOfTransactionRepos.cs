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
    public class TypeOfTransactionRepos : AbstractClass, ITypeOfTransactionRepo
    {
        private readonly DbSet<TypeOfTransaction> TypeOfTransaction;

        public TypeOfTransactionRepos(OptioDB optioDB) : base(optioDB)
        {
            TypeOfTransaction=context.Set<TypeOfTransaction>();
        }

        public Task<bool> Add(TypeOfTransaction entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TypeOfTransaction>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TypeOfTransaction> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(TypeOfTransaction entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TypeOfTransaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
