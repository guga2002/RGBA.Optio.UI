﻿using AutoMapper;
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

        public Task<bool> AddAsync(TransactionModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionModel>> GetActiveTransactionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(TransactionModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TransactionModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
