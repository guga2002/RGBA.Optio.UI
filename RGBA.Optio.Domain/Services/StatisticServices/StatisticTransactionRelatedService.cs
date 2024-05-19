using AutoMapper;
using Microsoft.Extensions.Logging;
using RGBA.Optio.Core.Interfaces;
using RGBA.Optio.Domain.Interfaces.StatisticInterfaces;
using RGBA.Optio.Domain.Models;
using RGBA.Optio.Domain.Models.ResponseModels;

namespace RGBA.Optio.Domain.Services.StatisticServices
{
    public class StatisticTransactionRelatedService : AbstractService<StatisticTransactionRelatedService>, IStatisticTransactionRelatedService
    {
        public StatisticTransactionRelatedService(IUniteOfWork work, IMapper map, ILogger<StatisticTransactionRelatedService> log) : base(work, map, log)
        {
        }

        public Task<IEnumerable<TransactionModel>> GetAllTransactionBetweenDate(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryResponseModel>> GetMostPopularCategoryAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TranscationQuantitiesWithDateModel>> GetTransactionQuantityWithDateAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
