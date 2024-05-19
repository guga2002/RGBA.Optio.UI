using AutoMapper;
using Microsoft.Extensions.Logging;
using RGBA.Optio.Core.Interfaces;
using RGBA.Optio.Domain.Interfaces.StatisticInterfaces;
using RGBA.Optio.Domain.Models.ResponseModels;

namespace RGBA.Optio.Domain.Services.StatisticServices
{
    public class StatisticMerchantRelatedService : AbstractService<StatisticMerchantRelatedService>, IStatisticMerchantRelatedService
    {
        public StatisticMerchantRelatedService(IUniteOfWork work, IMapper map, ILogger<StatisticMerchantRelatedService> log) : base(work, map, log)
        {
        }

        public Task<IEnumerable<ChannelResponseModel>> GetMostPopularChannelAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LocationResponseModel>> GetMostPopularLocationAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MerchantResponseModel>> GetMostPopularMerchantsAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
