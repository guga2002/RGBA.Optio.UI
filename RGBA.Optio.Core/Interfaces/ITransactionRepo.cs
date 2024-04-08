

using Optio.Core.Entities;

namespace Optio.Core.Interfaces
{
    public interface ITransactionRepo:ICrudRepo<Transaction>
    {
        Task<IEnumerable<Transaction>> GetAllWithDetails();

        Task<Transaction> GetByIdWithDetails(Guid Id);
    }
}
