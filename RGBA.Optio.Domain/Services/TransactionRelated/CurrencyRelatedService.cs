using AutoMapper;
using Microsoft.Extensions.Logging;
using RGBA.Optio.Core.Entities;
using RGBA.Optio.Core.Interfaces;
using RGBA.Optio.Domain.Custom_Exceptions;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Interfaces.InterfacesForTransaction;
using RGBA.Optio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Services.TransactionRelated
{
    public class CurrencyRelatedService : AbstractService<CurrencyRelatedService>, ICurrencyRelatedService
    {
        public CurrencyRelatedService(IUniteOfWork work, IMapper map, ILogger<CurrencyRelatedService> log) : base(work, map, log)
        {
        }

        public async Task<bool> AddAsync(CurrencyModel entity)
        {
            try
            {
                if (entity is null || string.IsNullOrWhiteSpace(entity.CurrencyCode) || string.IsNullOrEmpty(entity.NameOfValute))
                {
                    throw new OptioGeneralException("Entity can not be null");
                }
                var mapp = mapper.Map<Currency>(entity);
                if (mapp is not null)
                {
                    var res = await work.CurrencyRepository.AddAsync(mapp);
                    logger.LogInformation($"{entity.NameOfValute} is successfully added", DateTime.Now.ToShortDateString());
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

        public async Task<bool> AddAsync(ValuteModel entity)
        {
            try
            {
                if (entity is null || entity.CurrencyID < 0 || entity.ExchangeRate < 0 || string.IsNullOrEmpty(entity.DateOfValuteCourse.ToString()))
                {
                    throw new OptioGeneralException("Entity can not be null");
                }
                var mapp = mapper.Map<ValuteCourse>(entity);
                if (mapp is not null)
                {
                    var res = await work.ValuteCourse.AddAsync(mapp);
                    logger.LogInformation($"{entity.CurrencyID} is successfully added", DateTime.Now.ToShortDateString());
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

        public async Task<IEnumerable<CurrencyModel>> GetAllActiveAsync(CurrencyModel Identify)
        {
            try
            {
                var res = await work.CurrencyRepository.GetAllActiveAsync();
                if (res is not null)
                {
                    var mapp = mapper.Map<IEnumerable<CurrencyModel>>(res);
                    return mapp;
                }
                else
                {
                    return Enumerable.Empty<CurrencyModel>();
                }
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }


        public Task<IEnumerable<ValuteModel>> GetAllActiveAsync(ValuteModel Identify)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CurrencyModel>> GetAllAsync(CurrencyModel Identify)
        {
            try
            {
                var res = await work.CurrencyRepository.GetAllAsync();
                if (res is not null)
                {
                    var mapp = mapper.Map<IEnumerable<CurrencyModel>>(res);
                    return mapp;
                }
                return Enumerable.Empty<CurrencyModel>();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }


        public Task<IEnumerable<ValuteModel>> GetAllAsync(ValuteModel Identify)
        {
            throw new NotImplementedException();
        }

        public async Task<CurrencyModel> GetByIdAsync(int id, CurrencyModel Identify)
        {
            try
            {
                var res = await work.CurrencyRepository.GetByIdAsync(id);
                if (res is not null)
                {
                    var mapp = mapper.Map<CurrencyModel>(res);
                    return mapp;
                }
                else
                {
                    throw new ItemNotFoundException($"Currency with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public Task<ValuteModel> GetByIdAsync(Guid id, ValuteModel Identify)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(CurrencyModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(ValuteModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int id, CurrencyModel Identify)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(Guid id, ValuteModel Identify)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CurrencyModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ValuteModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
