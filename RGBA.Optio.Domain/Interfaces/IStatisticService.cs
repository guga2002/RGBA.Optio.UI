using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface IStatisticService
    {
        Task<IEnumerable<TransactionModel>> GetMostPopularTransactions(DateTime start, DateTime end);
        Task<IEnumerable<MerchantModel>> GetMostPopularMerchants(int count,DateTime start, DateTime end);
        Task<IEnumerable<CategoryModel>>GetMostPopularCategory(DateTime start, DateTime end);
        Task<IEnumerable<TransactionTypeModel>> GetMostPopularTransactionType(DateTime start, DateTime end);
        Task<IEnumerable<locationModel>> GetMostPopularLocation(DateTime start, DateTime end);
    }
}
