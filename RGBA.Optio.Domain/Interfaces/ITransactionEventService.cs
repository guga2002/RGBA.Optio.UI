using RGBA.Optio.Domain.Models;
using System.Collections;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface ITransactionEventService:Icrud<CategoryModel>,Icrud<ChanellModel>,Icrud<locationModel>,Icrud<MerchantModel>,Icrud<TransactionTypeModel>,Icrud<ValuteModel>
    {
        Task<CategoryModel> GetcategoryByidAsync(Guid id);
        Task<ChanellModel> GetChanellByIdAsync(Guid id);
        Task<MerchantModel> GetMerchantByItAsync(Guid Id);
        Task<locationModel> GetLocationByIdAsync(Guid id);
        Task<TransactionTypeModel> GetTransactionTypeByIdAsync(Guid id);
        Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync();
        Task<IEnumerable<ChanellModel>> GetAllChanellsAsync();
        Task<IEnumerable<MerchantModel>> GetAllMerchantsAsync();
        Task<IEnumerable<locationModel>> GetAllLocationsAsync();
        Task<IEnumerable<TransactionTypeModel>> GetAllTransactionTypesAsync();
        Task<ValuteModel> GetValueByIdAsync(Guid Id);
    }
}
