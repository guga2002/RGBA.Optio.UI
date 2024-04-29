using Optio.Core.Entities;
using System.Numerics;

namespace Optio.Core.Interfaces
{
    public interface IMerchantRepo:ICrudRepo<Merchant, long>
    {
        Task<IEnumerable<Merchant>> GetAllActiveMerchantAsync();
        Task<bool> AssignLocationtoMerchant(long Merchantid, long Locationid);
    }
}
