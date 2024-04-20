using Optio.Core.Entities;
using System.Numerics;

namespace Optio.Core.Interfaces
{
    public interface IMerchantRepo:ICrudRepo<Merchant, BigInteger>
    {
        Task<IEnumerable<Merchant>> GetAllActiveMerchantAsync();
        Task<bool> AssignLocationtoMerchant(BigInteger Merchantid, BigInteger Locationid);
    }
}
