using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface IStatisticService
    {
        Task<IEnumerable<TransactionModel>> GetMostPopularTransactionsAsync(DateTime start, DateTime end);
        Task<IEnumerable<MerchantModel>> GetMostPopularMerchantsAsync(int count,DateTime start, DateTime end);
        Task<IEnumerable<CategoryModel>> GetMostPopularCategoryAsync(DateTime start, DateTime end);
        Task<IEnumerable<TransactionTypeModel>> GetMostPopularTransactionTypeAsync(DateTime start, DateTime end);
        Task<IEnumerable<locationModel>> GetMostPopularLocationAsync(DateTime start, DateTime end);
    }
}
