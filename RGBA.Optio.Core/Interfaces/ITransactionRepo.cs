using Optio.Core.Entities;
using System.Numerics;

namespace Optio.Core.Interfaces
{
    public interface ITransactionRepo:ICrudRepo<Transaction, BigInteger>
    {
        Task<IEnumerable<Transaction>> GetAllWithDetailsAsync();

        Task<Transaction> GetByIdWithDetailsAsync(BigInteger Id);

        Task<IEnumerable<Transaction>> GetAllActiveAsync();
    }
}
