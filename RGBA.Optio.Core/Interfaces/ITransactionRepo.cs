

using Optio.Core.Entities;

namespace Optio.Core.Interfaces
{
    public interface ITransactionRepo:ICrudRepo<Transaction>
    {
        Task<IEnumerable<Transaction>> GetAllWithDetailsAsync();

        Task<Transaction> GetByIdWithDetailsAsync(Guid Id);

        Task<IEnumerable<Transaction>> GetAllActiveAsync();
    }
}
