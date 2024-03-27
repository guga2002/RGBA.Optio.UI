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

        public Task<bool> Add(CategoryModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(ChanellModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(locationModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(MerchantModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(TransactionTypeModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(ValuteModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChanellModel>> GetAllChanells()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<locationModel>> GetAllLocations()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MerchantModel>> GetAllMerchants()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionTypeModel>> GetAllTransactionTypes()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> GetcategoryByid(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ChanellModel> GetChanellById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<locationModel> GetLocationById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MerchantModel> GetMerchantByIt(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionTypeModel> GetTransactionTypeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ValuteModel> GetValueById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(CategoryModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(ChanellModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(locationModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(MerchantModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(TransactionTypeModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(ValuteModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(CategoryModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ChanellModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(locationModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(MerchantModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TransactionTypeModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ValuteModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
