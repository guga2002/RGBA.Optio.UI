using RGBA.Optio.Domain.Interfaces.InterfacesForTransaction;
using RGBA.Optio.Domain.Models;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface ITransactionService:IAddInfo<TransactionModel>, IUpdateInfo<TransactionModel>,IGetInfo<TransactionModel,Guid>,IRemoveInfo<TransactionModel,Guid>
    {
      
    }
}
