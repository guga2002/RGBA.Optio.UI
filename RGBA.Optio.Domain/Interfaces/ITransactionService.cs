using RGBA.Optio.Domain.Interfaces.InterfacesForTransaction;
using RGBA.Optio.Domain.Models;
using System.Numerics;

namespace RGBA.Optio.Domain.Interfaces
{
    public interface ITransactionService:IAddInfo<TransactionModel>, 
        IUpdateInfo<TransactionModel,BigInteger>,IGetInfo<TransactionModel,BigInteger>,IRemoveInfo<TransactionModel,BigInteger>
    {
      
    }
}
