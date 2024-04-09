using Optio.Core.Entities;

namespace Optio.Core.Interfaces
{
    public interface IMerchantRepo:ICrudRepo<Merchant>
    {
        Task<IEnumerable<Merchant>> GetAllActiveMerchantAsync();
    }
}
