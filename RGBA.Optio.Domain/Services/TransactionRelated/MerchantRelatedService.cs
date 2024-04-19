using AutoMapper;
using Microsoft.Extensions.Logging;
using Optio.Core.Entities;
using RGBA.Optio.Core.Interfaces;
using RGBA.Optio.Domain.Custom_Exceptions;
using RGBA.Optio.Domain.Interfaces;
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

        public async Task<bool> AssignLocationtoMerchant(Guid Merchantid, Guid Locationid)
        {
            try
            {
              var res= await  work.MerchantRepository.AssignLocationtoMerchant(Merchantid, Locationid);
              return res;
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public async Task<IEnumerable<locationModel>> GetAllActiveAsync(locationModel Identify)
        {
            try
            {
                var res =await work.LocationRepository.GetAllActiveLocationAsync();
                if(res is not null)
                {
                    var mapp=mapper.Map<IEnumerable<locationModel>>(res);
                    return mapp;
                }
                return Enumerable.Empty<locationModel>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public async Task<IEnumerable<MerchantModel>> GetAllActiveAsync(MerchantModel Identify)
        {
            try
            {
                var res = await work.MerchantRepository.GetAllActiveMerchantAsync();
                if (res is not null)
                {
                    var mapp = mapper.Map<IEnumerable<MerchantModel>>(res);
                    return mapp;
                }
                return Enumerable.Empty<MerchantModel>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
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


        public async Task<locationModel> GetByIdAsync(Guid id, locationModel Identify)
        {
            try
            {
                var res =await work.LocationRepository.GetByIdAsync(id);
                if(res is not null)
                {
                    var mapp=mapper.Map<locationModel>(res);
                    return mapp;
                }
                else
                {
                    throw new ItemNotFoundException($"Location with id: {id} not found");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public async Task<MerchantModel> GetByIdAsync(Guid id, MerchantModel Identify)
        {
            try
            {
                var res = await work.MerchantRepository.GetByIdAsync(id);
                if (res is not null)
                {
                    var mapp = mapper.Map<MerchantModel>(res);
                    return mapp;
                }
                else
                {
                    throw new ItemNotFoundException($"Merchant with id: {id} not found");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public async Task<bool> RemoveAsync(locationModel entity)
        {
            try
            {
                if (entity is null || string.IsNullOrWhiteSpace(entity?.LocationName))
                {
                    throw new OptioGeneralException("Entity can not be null");
                }
                var mapp = mapper.Map<Location>(entity);
                if(mapp is not null)
                {
                    var res=await work.LocationRepository.RemoveAsync(mapp);
                    return res;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public async Task<bool> RemoveAsync(MerchantModel entity)
        {
            try
            {
                if (entity is null || string.IsNullOrWhiteSpace(entity?.Name))
                {
                    throw new OptioGeneralException("Entity can not be null");
                }
                var mapp = mapper.Map<Merchant>(entity);
                if (mapp is not null)
                {
                    var res = await work.MerchantRepository.RemoveAsync(mapp);
                    return res;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public async Task<bool> SoftDeleteAsync(Guid id, locationModel Identify)
        {
            try
            {
                var res =await work.LocationRepository.SoftDeleteAsync(id);
                return res;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public async Task<bool> SoftDeleteAsync(Guid id, MerchantModel Identify)
        {
            try
            {
                var res = await work.MerchantRepository.SoftDeleteAsync(id);
                return res;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, locationModel entity)
        {
            try
            {
                if(entity is null || string.IsNullOrWhiteSpace(entity.LocationName))
                {
                    throw new OptioGeneralException("Entity can not be null");
                }
                var mapp=mapper.Map<Location>(entity);
                if(mapp is not null)
                {
                    var res=await work.LocationRepository.UpdateAsync(id,mapp);
                    return res;
                }
                else
                {
                    throw new ItemNotFoundException($"{entity.LocationName} not found");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public async Task<bool> UpdateAsync( Guid id,MerchantModel entity)
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
                    var res = await work.MerchantRepository.UpdateAsync(id,mapp);
                    return res;
                }
                else
                {
                    throw new ItemNotFoundException($"{entity.Name} not found");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }
    }
}
