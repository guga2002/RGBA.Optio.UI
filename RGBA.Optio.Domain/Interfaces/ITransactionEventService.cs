using RGBA.Optio.Domain.Models;
using System.Collections;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface ITransactionEventService:Icrud<CategoryModel>,Icrud<ChanellModel>,Icrud<locationModel>,Icrud<MerchantModel>,Icrud<TransactionTypeModel>,Icrud<ValuteModel>
    {
        Task<CategoryModel> GetcategoryByid(Guid id);
        Task<ChanellModel> GetChanellById(Guid id);
        Task<MerchantModel> GetMerchantByIt(Guid Id);
        Task<locationModel> GetLocationById(Guid id);
        Task<TransactionTypeModel> GetTransactionTypeById(Guid id);
        Task<IEnumerable<CategoryModel>> GetAllCategories();
        Task<IEnumerable<ChanellModel>> GetAllChanells();
        Task<IEnumerable<MerchantModel>> GetAllMerchants();
        Task<IEnumerable<locationModel>> GetAllLocations();
        Task<IEnumerable<TransactionTypeModel>> GetAllTransactionTypes();
        Task<ValuteModel> GetValueById(Guid Id);
    }
}
