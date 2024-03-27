using AutoMapper;
using Microsoft.Extensions.Logging;
using RGBA.Optio.Core.Interfaces;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.Domain.Services
{
    public class TransactionService : AbstractService<TransactionService>, ITransactionService
    {
        public TransactionService(IUniteOfWork work, IMapper map, ILogger<TransactionService> log) : base(work, map, log)
        {
        }

        public Task<bool> Add(TransactionModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TransactionModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(TransactionModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TransactionModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
