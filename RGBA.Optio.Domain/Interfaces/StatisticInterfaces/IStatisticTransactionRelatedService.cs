using RGBA.Optio.Domain.Models;
using RGBA.Optio.Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Interfaces.StatisticInterfaces
{
    public interface IStatisticTransactionRelatedService
    {
        Task<IEnumerable<CategoryResponseModel>> GetMostPopularCategoryAsync(DateTime start, DateTime end);
        Task<IEnumerable<TranscationQuantitiesWithDateModel>> GetTransactionQuantityWithDateAsync(DateTime start, DateTime end);
        Task<IEnumerable<TransactionModel>> GetAllTransactionBetweenDate(DateTime start, DateTime end);
    }
}
