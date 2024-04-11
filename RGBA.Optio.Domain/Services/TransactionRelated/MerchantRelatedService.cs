using AutoMapper;
using Microsoft.Extensions.Logging;
using Optio.Core.Entities;
using RGBA.Optio.Core.Interfaces;
using RGBA.Optio.Domain.Custom_Exceptions;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Interfaces.InterfacesForTransaction;
using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.Domain.Services.TransactionRelated
{
    public class MerchantRelatedService : AbstractService<MerchantRelatedService>, IMerchantRelatedService
    {
        public MerchantRelatedService(IUniteOfWork work, IMapper map, ILogger<MerchantRelatedService> log) : base(work, map, log)
        {
        }

        public async Task<bool> AddAsync(MerchantModel entity)
        {
            try
            {
                if (entity is null || string.IsNullOrWhiteSpace(entity.Name))
                {
                    throw new OptioGeneralException("Entity can not be null");
                }
                var mapp = mapper.Map<Merchant>(entity);
                if (mapp is not null)
                {
                    var res = await work.MerchantRepository.AddAsync(mapp);
                    logger.LogInformation($"{entity.Name} is successfully added", DateTime.Now.ToShortDateString());
                    return res;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public async Task<bool> AddAsync(locationModel entity)
        {
            try
            {
                if (entity is null || string.IsNullOrEmpty(entity.LocationName))
                {
                    throw new OptioGeneralException("Entity can not be null");
                }
                var mapp = mapper.Map<Location>(entity);
                if (mapp is not null)
                {
                    var res = await work.LocationRepository.AddAsync(mapp);
                    logger.LogInformation($"{entity.LocationName} is successfully added", DateTime.Now.ToShortDateString());
                    return res;
                }
                else { return false; }

            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public Task<IEnumerable<locationModel>> GetAllActiveAsync(locationModel Identify)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MerchantModel>> GetAllActiveAsync(MerchantModel Identify)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<locationModel>> GetAllAsync(locationModel Identify)
        {
            try
            {
                var res = await work.LocationRepository.GetAllAsync();
                if (res is not null)
                {
                    var mapp = mapper.Map<IEnumerable<locationModel>>(res);
                    return mapp;
                }
                return Enumerable.Empty<locationModel>();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }


        public async Task<IEnumerable<MerchantModel>> GetAllAsync(MerchantModel Identify)
        {
            try
            {
                var res = await work.MerchantRepository.GetAllAsync();
                if (res is not null)
                {
                    var mapp = mapper.Map<IEnumerable<MerchantModel>>(res);
                    return mapp;
                }
                return Enumerable.Empty<MerchantModel>();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }


        public Task<locationModel> GetByIdAsync(Guid id, locationModel Identify)
        {
            throw new NotImplementedException();
        }

        public Task<MerchantModel> GetByIdAsync(Guid id, MerchantModel Identify)
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

        public Task<bool> SoftDeleteAsync(Guid id, locationModel Identify)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(Guid id, MerchantModel Identify)
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
    }
}
