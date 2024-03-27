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

        public Task<IEnumerable<CategoryModel>> GetMostPopularCategory(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<locationModel>> GetMostPopularLocation(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MerchantModel>> GetMostPopularMerchants(int count, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionModel>> GetMostPopularTransactions(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionTypeModel>> GetMostPopularTransactionType(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
