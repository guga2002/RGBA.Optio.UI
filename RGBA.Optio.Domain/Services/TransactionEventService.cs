using AutoMapper;
using Microsoft.Extensions.Logging;
using RGBA.Optio.Core.Interfaces;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.Domain.Services
{
    public class TransactionEventService : AbstractService<TransactionEventService>, ITransactionEventService
    {
        public TransactionEventService(IUniteOfWork work, IMapper map, ILogger<TransactionEventService> log) : base(work, map, log)
        {
        }

        public Task<bool> AddAsync(CategoryModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(ChanellModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(locationModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(MerchantModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(TransactionTypeModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(ValuteModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChanellModel>> GetAllChanellsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<locationModel>> GetAllLocationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MerchantModel>> GetAllMerchantsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionTypeModel>> GetAllTransactionTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> GetcategoryByidAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ChanellModel> GetChanellByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<locationModel> GetLocationByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MerchantModel> GetMerchantByItAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionTypeModel> GetTransactionTypeByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ValuteModel> GetValueByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(CategoryModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(ChanellModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(locationModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(MerchantModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(TransactionTypeModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(ValuteModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CategoryModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ChanellModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(locationModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(MerchantModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TransactionTypeModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ValuteModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
