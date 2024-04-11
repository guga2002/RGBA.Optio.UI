using AutoMapper;
using Microsoft.Extensions.Logging;
using Optio.Core.Entities;
using RGBA.Optio.Core.Interfaces;
using RGBA.Optio.Domain.Custom_Exceptions;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Services.TransactionRelated
{
    public class TransactionRelatedService : AbstractService<TransactionRelatedService>, ITransactionRelatedService
    {
        public TransactionRelatedService(IUniteOfWork work, IMapper map, ILogger<TransactionRelatedService> log) : base(work, map, log)
        {
        }

        public async Task<bool> AddAsync(ChanellModel entity)
        {
            try
            {
                if (entity is null || string.IsNullOrWhiteSpace(entity.ChannelType))
                {
                    throw new OptioGeneralException("Entity can not be null");
                }
                var mapp = mapper.Map<Channels>(entity);
                if (mapp is not null)
                {
                    var res = await work.ChanellRepository.AddAsync(mapp);
                    logger.LogInformation($"{entity.ChannelType} is successfully added", DateTime.Now.ToShortDateString());
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


        public async Task<bool> AddAsync(CategoryModel entity)
        {
            try
            {
                if (entity is null || string.IsNullOrEmpty(entity.TransactionCategory))
                {
                    throw new OptioGeneralException("Entity can not be null");
                }
                var mapped = mapper.Map<Category>(entity);
                if (mapped is not null)
                {
                    var res = await work.CategoryOfTransactionRepository.AddAsync(mapped);
                    logger.LogInformation($"{entity.TransactionCategory} is successfully added", DateTime.Now.ToShortDateString());
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

  
        public async Task<bool> AddAsync(TransactionTypeModel entity)
        {
            try
            {
                if (entity is null || string.IsNullOrWhiteSpace(entity.TransactionName))
                {
                    throw new OptioGeneralException("Entity can not be null");
                }
                var mapp = mapper.Map<TypeOfTransaction>(entity);
                if (mapp is not null)
                {
                    var res = await work.TypeOfTransactionRepository.AddAsync(mapp);
                    logger.LogInformation($"{entity.TransactionName} is successfully added", DateTime.Now.ToShortDateString());
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


        public Task<IEnumerable<ChanellModel>> GetAllActiveAsync(ChanellModel Identify)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryModel>> GetAllActiveAsync(CategoryModel Identify)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionTypeModel>> GetAllActiveAsync(TransactionTypeModel Identify)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ChanellModel>> GetAllAsync(ChanellModel Identify)
        {
            try
            {
                var res = await work.ChanellRepository.GetAllAsync();
                if (res is not null)
                {
                    var mapp = mapper.Map<IEnumerable<ChanellModel>>(res);
                    return mapp;
                }
                return Enumerable.Empty<ChanellModel>();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync(CategoryModel Identify)
        {

            try
            {
                var res = await work.CategoryOfTransactionRepository.GetAllAsync();
                if (res is not null)
                {
                    var mapp = mapper.Map<IEnumerable<CategoryModel>>(res);
                    return mapp;
                }
                return Enumerable.Empty<CategoryModel>();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }


        public async Task<IEnumerable<TransactionTypeModel>> GetAllAsync(TransactionTypeModel Identify)
        {
            try
            {
                var res = await work.TypeOfTransactionRepository.GetAllAsync();
                if (res is not null)
                {
                    var mapp = mapper.Map<IEnumerable<TransactionTypeModel>>(res);
                    return mapp;
                }
                return Enumerable.Empty<TransactionTypeModel>();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }


        public async Task<ChanellModel> GetByIdAsync(Guid id, ChanellModel Identify)
        {
            try
            {
                var res = await work.ChanellRepository.GetByIdAsync(id);
                if (res is not null)
                {
                    var mapp = mapper.Map<ChanellModel>(res);
                    return mapp;
                }
                else
                {
                    throw new ItemNotFoundException($"Channel by id: {id} not found");
                }
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }


        public async Task<CategoryModel> GetByIdAsync(Guid id, CategoryModel Identify)
        {
            try
            {
                var res = await work.CategoryOfTransactionRepository.GetByIdAsync(id);
                if (res is not null)
                {
                    var mapp = mapper.Map<CategoryModel>(res);
                    return mapp;
                }
                else
                {
                    throw new ItemNotFoundException($"Category by id: {id} not found");
                }
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex.StackTrace, DateTime.Now.ToShortTimeString());
                throw;
            }
        }


        public Task<TransactionTypeModel> GetByIdAsync(Guid id, TransactionTypeModel Identify)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(ChanellModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(CategoryModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(TransactionTypeModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(Guid id, ChanellModel Identify)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(Guid id, CategoryModel Identify)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(Guid id, TransactionTypeModel Identify)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ChanellModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CategoryModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TransactionTypeModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
