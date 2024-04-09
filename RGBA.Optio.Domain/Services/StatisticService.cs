using AutoMapper;
using Microsoft.Extensions.Logging;
using RGBA.Optio.Core.Interfaces;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.Domain.Services
{
    public class StatisticService : AbstractService<StatisticService>, IStatisticService
    {
        public StatisticService(IUniteOfWork work, IMapper map, ILogger<StatisticService> log) : base(work, map, log)
        {
        }

        public Task<IEnumerable<CategoryModel>> GetMostPopularCategoryAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<locationModel>> GetMostPopularLocationAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MerchantModel>> GetMostPopularMerchantsAsync(int count, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionModel>> GetMostPopularTransactionsAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionTypeModel>> GetMostPopularTransactionTypeAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
